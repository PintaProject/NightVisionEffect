// 
// NightVisionEffect.cs
//  
// Author:
//       Robert Nordan <rpvn@robpvn.net>
// 
// Copyright (c) 2013 Robert Nordan
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Pinta.Core;

namespace NightVisionAddin
{
	public class NightVisionEffect : BaseEffect
	{
		public NightVisionEffect ()
		{
		}

		//TODO: This needs to translate with GetString, but currently Mono.Posix is broken on Windows
		public override string Name { get { return "Night Vision"; }}
		public override string EffectMenuCategory { get { return "Stylize"; }}

		//We don't make this one configurable (At the moment), so no need for all those overrides
		//TODO: Add a GUI to configure
		//TODO: Pull in other effects like noise and soften to make it even more nightvision-y

		protected override ColorBgra Render (ColorBgra pixel)
		{
			pixel.G = Utility.ClampToByte((int)((float)pixel.B * 0.1 + (float)pixel.G * 0.6 + (float)pixel.R * 0.2));
			pixel.B = 0;
			pixel.R = 0;

			return pixel;
		}
	}
}

