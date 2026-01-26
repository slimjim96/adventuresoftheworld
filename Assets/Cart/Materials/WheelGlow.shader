Shader "Custom/WheelGlow2D"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _GlowColor ("Glow Color", Color) = (1,1,0.8,1)
        _GlowIntensity ("Glow Intensity", Range(0, 2)) = 0.5
        _HighlightAngle ("Highlight Angle", Range(0, 360)) = 45
        _HighlightWidth ("Highlight Width", Range(0, 1)) = 0.3
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
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
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            fixed4 _GlowColor;
            float _GlowIntensity;
            float _HighlightAngle;
            float _HighlightWidth;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Sample the texture
                fixed4 texColor = tex2D(_MainTex, i.uv);

                // Calculate position from center
                float2 center = float2(0.5, 0.5);
                float2 dir = i.uv - center;
                float dist = length(dir);

                // Calculate angle
                float angle = atan2(dir.y, dir.x) * 57.2958; // radians to degrees
                angle = (angle + 360.0 + _HighlightAngle) % 360.0;

                // Create highlight based on angle
                float highlight = 1.0 - smoothstep(0, _HighlightWidth * 180, abs(angle - 180));

                // Add radial falloff (brighter in center, darker at edges)
                float radialGlow = 1.0 - smoothstep(0.2, 0.5, dist);

                // Combine glow effects
                float glow = highlight * radialGlow * _GlowIntensity;

                // Apply glow to the color
                fixed4 finalColor = texColor * i.color;
                finalColor.rgb += _GlowColor.rgb * glow;

                return finalColor;
            }
            ENDCG
        }
    }

    Fallback "Sprites/Default"
}
