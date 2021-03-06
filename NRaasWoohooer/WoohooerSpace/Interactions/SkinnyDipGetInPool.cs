﻿using NRaas.WoohooerSpace.Helpers;
using Sims3.Gameplay;
using Sims3.Gameplay.Abstracts;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.Autonomy;
using Sims3.Gameplay.Careers;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.CelebritySystem;
using Sims3.Gameplay.Controllers;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.EventSystem;
using Sims3.Gameplay.Interactions;
using Sims3.Gameplay.Interfaces;
using Sims3.Gameplay.Objects.Miscellaneous;
using Sims3.Gameplay.Pools;
using Sims3.Gameplay.Skills;
using Sims3.Gameplay.Situations;
using Sims3.Gameplay.Socializing;
using Sims3.Gameplay.Utilities;
using Sims3.Gameplay.UI;
using Sims3.SimIFace;
using Sims3.SimIFace.CAS;
using Sims3.UI;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NRaas.WoohooerSpace.Interactions
{
    public class SkinnyDipGetInPool : GetInPool, Common.IPreLoad, Common.IAddInteraction
    {
        static InteractionDefinition sOldSingleton;

        public void OnPreLoad()
        {
            InteractionTuning tuning = Woohooer.InjectAndReset<Pool, GetInPool.SkinnyDipDefinition, Definition>(false);

            if (tuning != null)
            {
                tuning.Availability.SetFlags(Availability.FlagField.DisallowedIfPregnant, false);
            }

            sOldSingleton = SkinnyDipSingleton;
            SkinnyDipSingleton = new Definition();
        }

        public void AddInteraction(Common.InteractionInjectorList interactions)
        {
            interactions.Replace<Pool, GetInPool.SkinnyDipDefinition>(SkinnyDipSingleton);
        }

        public override bool Run()
        {
            try
            {
                // Stops EA Standard from performing its teen checks
                if (!Target.mSkinnyDipperList.Contains(Actor.SimDescription.SimDescriptionId))
                {
                    Target.mSkinnyDipperList.Add(Actor.SimDescription.SimDescriptionId);
                }

                bool success = base.Run();

                if (Actor.Posture is SwimmingInPool)
                {
                    PoolEx.AddSkinnyDipper(Target, Actor);
                }

                return success;
            }
            catch (ResetException)
            {
                throw;
            }
            catch (Exception e)
            {
                Common.Exception(Actor, Target, e);
                return false;
            }
        }

        public new class Definition : GetInPool.SkinnyDipDefinition
        {
            public override InteractionInstance CreateInstance(ref InteractionInstanceParameters parameters)
            {
                InteractionInstance result = new SkinnyDipGetInPool();
                result.Init(ref parameters);
                return result;
            }
   
            public override string GetInteractionName(Sim actor, Pool target, InteractionObjectPair iop)
            {
                return base.GetInteractionName(actor, target, new InteractionObjectPair(sOldSingleton, target));
            }

            public override InteractionTestResult Test(ref InteractionInstanceParameters parameters, ref GreyedOutTooltipCallback greyedOutTooltipCallback)
            {
                using (WoohooTuningControl control = new WoohooTuningControl(parameters.InteractionObjectPair.Tuning, Woohooer.Settings.mAllowTeenSkinnyDip))
                {
                    return base.Test(ref parameters, ref greyedOutTooltipCallback);
                }
            }
        }
    }
}
