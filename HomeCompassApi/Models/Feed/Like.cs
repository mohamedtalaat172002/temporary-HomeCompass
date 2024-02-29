<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
=======
﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
>>>>>>> 449c26d641cf51f1dad16e034a56311b33416a6b

namespace HomeCompassApi.Models.Feed
{
    [PrimaryKey(nameof(UserId), nameof(PostId))]
    public class Like
    {
        [Required]
        public int LikeId { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public ApplicationUser User { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        [JsonIgnore]
        public Post Post { get; set; }
    }
}