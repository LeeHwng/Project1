using System;
using System.Collections.Generic;

namespace Qhluxury.Models;

public partial class Hanghoa
{
    public int Mahang { get; set; }

    public string Tenhang { get; set; } = null!;

    public int Maloaihang { get; set; }

    public int Gia { get; set; }

    public int Soluong { get; set; }

    public string Anh { get; set; } = null!;
}
