using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Dto.Response
{
    public class ConcertResponseDto
    {
        public string Title { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Place { get; set; } = default!;

        public double UnitPrice { get; set; }

        public int GenreId { get; set; }

        public string DateEvent { get; set; } = default!;

        public string TimeEvent { get; set; } = default!;

        public string? Imageurl { get; set; }

        public int TicketsQuantity { get; set; }

        public string Status { get; set; } = default!;

        public bool Finalized { get; set; }
    }
}
