using Pandora.NetStandard.Model.Entities;
using Reinforced.Typings.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pandora.NetStandard.Model.Dtos
{
    [TsInterface(AutoI = false, Name = "ClassRoom")]
    public class ClassRoomDto : ClassRoom
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Description { get => base.Description; set => base.Description = value; }
        public override short Capacity { get => base.Capacity; set => base.Capacity = value; }
        public override bool? HasNetworkConexion { get => base.HasNetworkConexion; set => base.HasNetworkConexion = value; }
        public override bool? HasScreenProjector { get => base.HasScreenProjector; set => base.HasScreenProjector = value; }
    }
}
