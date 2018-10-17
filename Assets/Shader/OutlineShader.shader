Shader "Custom/Outline" {
    Properties {
    	_Color ("Color", Color) = (1,1,1,1)
    	_ColorOffset ("Offset", Color) = (0,0,0,0)
        _MainTex ("MainTex", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
        _Outline ("Stroke", Range(0,0.1)) = 0
        _OutlineColor ("Outline Color", Color) = (1, 1, 1, 1)
        [Enum(OFF,0,ON,1)] _Culling ("Backface Culling", Float) = 0.0
    }
    SubShader {
        Pass {
            Tags { "RenderType"="Opaque" }
            Cull [_Culling]
 
            CGPROGRAM
 
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct v2f {
                float4 pos : SV_POSITION;
            };

            float _Outline;
            float4 _OutlineColor;
 
            float4 vert(appdata_base v) : SV_POSITION {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                float3 normal = mul((float3x3) UNITY_MATRIX_MV, v.normal);
                normal.x *= UNITY_MATRIX_P[0][0];
                normal.y *= UNITY_MATRIX_P[1][1];
                o.pos.xy += normal.xy * _Outline;
                return o.pos;
            }
 
            half4 frag(v2f i) : COLOR {
                return _OutlineColor;
            }
 
            ENDCG
        }
 
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
 
        sampler2D _MainTex;
 
        struct Input {
            float2 uv_MainTex;
        };

        half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		fixed4 _ColorOffset;
 
        void surf(Input IN, inout SurfaceOutputStandard o) {
            // Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color + _ColorOffset;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
        }
 
        ENDCG
    }
    FallBack "Diffuse"
}