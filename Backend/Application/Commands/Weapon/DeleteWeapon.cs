using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands.Weapon
{
    public class DeleteWeapon
    {
        [JsonIgnore]
        public Guid WeaponId;
    }
}
