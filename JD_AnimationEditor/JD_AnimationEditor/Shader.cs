﻿using System;
using System.IO;
using System.Reflection;
using System.Text;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JD_AnimationEditor
{

        public class Shader 
        {
                private int iVertexShader;
                private int iFragShader;

                private int iProgram;

                public Shader(string vertex, string frag) 
                {
                        iProgram = GL.CreateProgram();
                        int result;

                        iVertexShader = GL.CreateShader(ShaderType.VertexShader);
                        GL.ShaderSource(iVertexShader, vertex);
                        GL.CompileShader(iVertexShader);
                        GL.GetShader(iVertexShader, ShaderParameter.CompileStatus, out result);
                        if(result == 0) 
                        {
                                System.Diagnostics.Debug.WriteLine("Failed to compile vertex shader!");
                                System.Diagnostics.Debug.WriteLine(GL.GetShaderInfoLog(iVertexShader));
                        }

                        iFragShader = GL.CreateShader(ShaderType.FragmentShader);
                        GL.ShaderSource(iFragShader, frag);
                        GL.CompileShader(iFragShader);
                        GL.GetShader(iFragShader, ShaderParameter.CompileStatus, out result);
                        if(result == 0) 
                        {
                                System.Diagnostics.Debug.WriteLine("Failed to compile fragment shader!");
                                System.Diagnostics.Debug.WriteLine(GL.GetShaderInfoLog(iFragShader));
                        }

                        GL.AttachShader(iProgram, iVertexShader);
                        GL.AttachShader(iProgram, iFragShader);

                        GL.LinkProgram(iProgram);

                        GL.GetProgram(iProgram, ProgramParameter.LinkStatus, out result);
                        if(result == 0) 
                        {
                                System.Diagnostics.Debug.WriteLine("Failed to link shader program!");
                                System.Diagnostics.Debug.WriteLine(GL.GetProgramInfoLog(iProgram));
                        }
                }

                public void SetUniform(string name, float value) 
                {
                        int loc = GL.GetUniformLocation(iProgram, name);
                        GL.Uniform1(loc, value);
                }
                public void SetUniform(string name, Vector3 value) 
                {
                        int loc = GL.GetUniformLocation(iProgram, name);
                        GL.Uniform3(loc, ref value);
                }
                public void SetUniform(string name, int value) 
                {
                        int loc = GL.GetUniformLocation(iProgram, name);
                        GL.Uniform1(loc, value);
                }

                public void Activate() 
                {
                        GL.UseProgram(iProgram);
                }

                public void Deactivate() 
                {
                        GL.UseProgram(0);
                }


        }
}
