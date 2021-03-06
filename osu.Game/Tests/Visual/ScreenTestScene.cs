﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Screens;

namespace osu.Game.Tests.Visual
{
    /// <summary>
    /// A test case which can be used to test a screen (that relies on OnEntering being called to execute startup instructions).
    /// </summary>
    public abstract class ScreenTestScene : ManualInputManagerTestScene
    {
        protected readonly OsuScreenStack Stack;

        private readonly Container content;

        protected override Container<Drawable> Content => content;

        protected ScreenTestScene()
        {
            base.Content.AddRange(new Drawable[]
            {
                Stack = new OsuScreenStack { RelativeSizeAxes = Axes.Both },
                content = new Container { RelativeSizeAxes = Axes.Both }
            });
        }

        protected void LoadScreen(OsuScreen screen)
        {
            if (Stack.CurrentScreen != null)
                Stack.Exit();
            Stack.Push(screen);
        }
    }
}
