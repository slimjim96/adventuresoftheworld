Shader "Custom/SpriteEdgeFade"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

        [Header(Edge Fade Settings)]
        _FadeStart ("Fade Start (0-1)", Range(0, 1)) = 0.3
        _FadeEnd ("Fade End (0-1)", Range(0, 1)) = 0.5
        _EllipseX ("Ellipse Width", Range(0.1, 2)) = 1.0
        _EllipseY ("Ellipse Height", Range(0.1, 2)) = 1.0
        _CenterX ("Center X Offset", Range(-0.5, 0.5)) = 0.0
        _CenterY ("Center Y Offset", Range(-0.5, 0.5)) = 0.0

        [Header(Haze Settings)]
        _HazeColor ("Haze Color", Color) = (0.7, 0.8, 0.9, 1)
        _HazeAmount ("Haze Amount", Range(0, 1)) = 0.0
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;

            float _FadeStart;
            float _FadeEnd;
            float _EllipseX;
            float _EllipseY;
            float _CenterX;
            float _CenterY;

            fixed4 _HazeColor;
            float _HazeAmount;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color * _Color;

                #ifdef PIXELSNAP_ON
                o.vertex = UnityPixelSnap(o.vertex);
                #endif

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Sample the sprite texture
                fixed4 texColor = tex2D(_MainTex, i.uv) * i.color;

                // Calculate distance from center with ellipse scaling
                float2 center = float2(0.5 + _CenterX, 0.5 + _CenterY);
                float2 offset = i.uv - center;

                // Apply ellipse scaling
                offset.x /= _EllipseX;
                offset.y /= _EllipseY;

                // Calculate normalized distance (0 at center, 1 at ellipse edge)
                float dist = length(offset) * 2.0;

                // Calculate fade based on distance
                float fade = 1.0 - smoothstep(_FadeStart, _FadeEnd, dist);

                // Apply haze (blend toward haze color)
                texColor.rgb = lerp(texColor.rgb, _HazeColor.rgb, _HazeAmount);

                // Apply edge fade to alpha
                texColor.a *= fade;

                return texColor;
            }
            ENDCG
        }
    }

    Fallback "Sprites/Default"
}
