Shader "Custom/UnLit_Color" {

	Properties {
		

		_alpha ("alpha", float) = 1.0
	}
	SubShader {
		Tags { "RenderType"="Transparent" "Queue" = "Transparent" "IgnoreProjector"= "True" }
		cull off
		ZWrite off
		Lighting off
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100
		
		Pass{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				
				#include "UnityCG.cginc" 
				
				struct VERTEXDATA {
					float4 vertex:POSITION;
					//float2 texcoord: TEXCOORD0;
					float4 color : COLOR;

				};
				
				struct FRAGMENTDATA
				{
					float4 vertex: SV_POSITION;
					//half2 texcoord :TEXCOORD0;
					float4 color : COLOR;
				};
				
				//sampler2D _MainTex;
				//float4 _MainTex_ST;
				
				float _alpha;
				FRAGMENTDATA vert (VERTEXDATA v)
				{
					FRAGMENTDATA o;
					o.vertex = mul(UNITY_MATRIX_MVP,v.vertex);
					//o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
					o.color=v.color;
					return o;
				}
				
				fixed4 frag (FRAGMENTDATA f):COLOR
				{
					fixed4 o;
					o=fixed4(f.color.r,f.color.g,f.color.b,f.color.a*_alpha);
					return o;
				}
				
			
			ENDCG
		}

	} 

}
