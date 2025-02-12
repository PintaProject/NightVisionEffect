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
using System.Threading.Tasks;
using Cairo;
using Pinta.Core;
using Pinta.Gui.Widgets;
using Mono.Addins;
using Pinta.Effects;

namespace NightVisionAddin;

public sealed class NightVisionEffect : BaseEffect
{
	public NightVisionEffect ()
	{
		EffectData = new NightVisionData ();
	}

	public override string Name => AddinManager.CurrentLocalizer.GetString ("Night Vision");
	public override string EffectMenuCategory => AddinManager.CurrentLocalizer.GetString ("Stylize");

	//TODO: Pull in other effects like noise and soften to make it even more nightvision-y

	public override bool IsConfigurable => true;

	public override bool IsTileable => true;

	public override Task<bool> LaunchConfiguration ()
	{
		return LaunchSimpleEffectDialog (AddinManager.CurrentLocalizer);
	}

	public NightVisionData Data => (NightVisionData) EffectData!; // NRT - Set in constructor.

	public override void Render (ImageSurface src, ImageSurface dst, ReadOnlySpan<RectangleI> rois)
	{
		if (!Data.Noise) {
			foreach (var rect in rois)
				Render (src, dst, rect); //Uses superclass chain of rendering to pass render down to single-pixel renderer.
		} else {
			AddNoiseEffect noiseEffect = new (PintaCore.Services);

			noiseEffect.Render (src, dst, rois);

			foreach (var rect in rois)
				Render (dst, dst, rect); //Have it render colour changes pixel by pixel on the modified surface.
		}
	}

	protected override ColorBgra Render (in ColorBgra pixel)
	{
		return ColorBgra.FromBgra (
			b: 0,
			g: Utility.ClampToByte ((int) ((float) pixel.B * 0.1 + (float) pixel.G * Data.Brightness + (float) pixel.R * 0.2)),
			r: 0,
			a: pixel.A);
	}

	public sealed class NightVisionData : EffectData
	{
		[Caption ("Brightness"), MinimumValue (0), MaximumValue (1)]
		public double Brightness { get; set; } = 0.6;

		[Caption ("Noise")]
		public bool Noise { get; set; } = false;
	}
}

