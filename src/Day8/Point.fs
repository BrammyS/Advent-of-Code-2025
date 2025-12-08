module Day8.Point

type Point = { X: float; Y: float; Z: float }

let parsePoint (line: string) : Point =
    let parts = line.Split(',')

    { X = float parts[0]
      Y = float parts[1]
      Z = float parts[2] }

let rec parsePoints (lines: string[]) (points: Point array) : Point array =
    if lines.Length > 0 then
        points[points.Length - lines.Length] <- parsePoint lines[0]
        parsePoints lines[1..] points
    else
        points
