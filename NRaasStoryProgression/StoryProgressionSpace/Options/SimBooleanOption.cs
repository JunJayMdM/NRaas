using NRaas.StoryProgressionSpace.Interfaces;
using NRaas.StoryProgressionSpace.Managers;
using NRaas.StoryProgressionSpace.Scenarios.Romances;
using Sims3.Gameplay.Actors;
using Sims3.Gameplay.ActorSystems;
using Sims3.Gameplay.CAS;
using Sims3.Gameplay.Core;
using Sims3.Gameplay.UI;
using Sims3.Gameplay.Utilities;
using Sims3.SimIFace;
using Sims3.UI;
using System;
using System.Collections.Generic;

namespace NRaas.StoryProgressionSpace.Options
{
    public abstract class SimBooleanOption : GenericOptionBase.BooleanOption, IReadSimLevelOption, IWriteSimLevelOption, IHouseLevelSimOption
    {
        public SimBooleanOption(bool defValue)
            : base(defValue)
        { }

        public override bool Value
        {
            get
            {
                if (!ShouldDisplay()) return false;

                return base.Value;
            }
        }

        public override bool ShouldDisplay()
        {
            if (GetValue<InStasisOption, bool>()) return false;

            return base.ShouldDisplay();
        }
    }
}
