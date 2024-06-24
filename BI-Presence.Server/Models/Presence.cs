using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BI_Presence.Server.Models
{
    public enum PresenceTypeEnum
    {
        Masuk,
        Pulang,
        TidakMasukAtauPulang,
    }

    public enum PresenceStatusEnum
    {
        Izin,
        Cuti,
        Sakit,
        Alpha,
        Hadir
    }

    public class Presence
    {
        public int Id { get; set; }
        public string FacePictureURL { get; set; } = string.Empty;
        public float Confidence { get; set; }
        public PresenceTypeEnum Type { get; set; } = PresenceTypeEnum.TidakMasukAtauPulang;
        public PresenceStatusEnum Status { get; set; } = PresenceStatusEnum.Alpha;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}