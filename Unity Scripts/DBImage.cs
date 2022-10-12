using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBImage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] ImageBlob { get; set; }
    public bool? IsBack { get; set; }
    public string? Theme { get; set; }
}
