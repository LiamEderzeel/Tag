Shader "custom/xray"{
	Properties {
		_Color ("Color", Color) = (1.0,1.0,1.0,1.0)
		_SpecColor ("Specular Color", Color) = (1.0,1.0,1.0,1.0)
		_Shininess ("Shininess", Float) = 10
		_RimCol ("Rim Color" , Color) = (1,0,0,1)
        _RimPow ("Rim Power", Float) = 1.0
	}
	SubShader {
		Pass {
                Name "Behind"
                Tags { "RenderType"="transparent" "Queue" = "Transparent" }
                Blend SrcAlpha OneMinusSrcAlpha
                ZTest Greater               // here the check is for the pixel being greater or closer to the camera, in which
                Cull Back                   // case the model is behind something, so this pass runs
                ZWrite Off
                LOD 200                    
               
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
               
                struct vertexOutput {
                    float4 pos : SV_POSITION;
                    float3 normal : TEXCOORD1;      // Normal needed for rim lighting
                    float3 viewDir : TEXCOORD2;     // as is view direction.
                };
               
                float4 _RimCol;
                float _RimPow;

                vertexOutput vert (appdata_tan v)
                {
                    vertexOutput o;
                    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                    o.normal = normalize(v.normal);
                    o.viewDir = normalize(ObjSpaceViewDir(v.vertex));       //this could also be WorldSpaceViewDir, which would
                    return o;                                               //return the World space view direction.
                }
               
                half4 frag (vertexOutput i) : COLOR
                {
                    half Rim = 1 - saturate(dot(normalize(i.viewDir), i.normal));       //Calculates where the model view falloff is       
                                                                                        //for rim lighting.
                   
                    half4 RimOut = _RimCol * pow(Rim, _RimPow);
                    return RimOut;
                }
                ENDCG
            }
	
	
	
		Pass {												//standard lighting
		Name "Regular"
		Tags {"RenderType"="Opaque" "Queue" = "Geometry"}
		ZTest LEqual										//Ckeck for the pixel being in front or at the same depth
		Zwrite On											
		Cull Back
		LOD 200
		CGPROGRAM
		
		#pragma vertex vert
		#pragma fragment frag
		
		//user difened variables
		uniform float4 _Color;
		uniform float4 _SpecColor;
		uniform float _Shininess;
		
		//Unity defined variables
		uniform float4 _LightColor0;						//ambient light (passed on from within Unity
		
		//structs
		struct vertexInput {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};
		
		struct vertexOutput {
			float4 pos : SV_POSITION;
			float4 col : COLOR;
			};
		
		//vertex function
		vertexOutput vert(vertexInput v){
			vertexOutput o;
			
			//vectors
			float3 normalDirection = normalize(mul( float4(v.normal, 0.0), _World2Object).xyz);
			float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - mul(_Object2World, v.vertex).xyz));
			float3 lightDirection;
			float atten = 1.0;
			
			//Lighting
			lightDirection = normalize(_WorldSpaceLightPos0.xyz);
			float3 diffuseReflection = atten * _LightColor0.xyz * max(0.0,dot(normalDirection, lightDirection));
			float3 specularReflection = atten * _SpecColor.rgb * max(0.0,dot(normalDirection, lightDirection)) * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
			float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;
			o.col = float4(lightFinal * _Color, 1.0);
			o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
			return o;
		
		}
		
		//Fragment Function
		half4 frag(vertexOutput i ) : COLOR
		{
			return i.col;
		}
		ENDCG
		}
	}
	fallback "Diffuse"
}