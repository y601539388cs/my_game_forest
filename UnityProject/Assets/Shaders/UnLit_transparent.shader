Shader "Custom/UnLit_transparent" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
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
					float2 texcoord: TEXCOORD0;
				};
				
				struct FRAGMENTDATA
				{
					float4 vertex: SV_POSITION;
					half2 texcoord :TEXCOORD0;
				};
				
				sampler2D _MainTex;
				float4 _MainTex_ST;
				
				FRAGMENTDATA vert (VERTEXDATA v)
				{
					FRAGMENTDATA o;
					o.vertex = mul(UNITY_MATRIX_MVP,v.vertex);
					o.texcoord = TRANSFORM_TEX(v.texcoord,_MainTex);
					return o;
				}
				
				fixed4 frag (FRAGMENTDATA f):COLOR
				{
					fixed4 o;
					o=tex2D(_MainTex,f.texcoord);
					return o;
				}
				
			
			ENDCG
		}

	} 

}
