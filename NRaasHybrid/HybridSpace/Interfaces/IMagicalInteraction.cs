﻿using NRaas.CommonSpace.Booters;
using NRaas.CommonSpace.Helpers;
using NRaas.HybridSpace.Helpers;
using NRaas.HybridSpace.MagicControls;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Objects.Alchemy;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using Sims3.UI.Hud;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.HybridSpace.Interfaces
{
    public interface IMagicalInteraction : IMagicalSubInteraction
    {
        void ShowEpicFailVfx(StateMachineClient sender, IEvent evt);
        void ShowFailVfx(StateMachineClient sender, IEvent evt);
        void ShowSuccessVfx(StateMachineClient sender, IEvent evt);

        void OnSpellEpicFailure();
        void OnSpellSuccess();
    }
}
