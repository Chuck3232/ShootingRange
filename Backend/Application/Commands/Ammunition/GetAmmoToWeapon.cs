﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands.Ammunition
{
    public class GetAmmoToWeapon
    {
        [JsonIgnore]
        public Guid WeaponId;
    }
}
