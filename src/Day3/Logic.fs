module Day3.Logic

let calculateJoltage (batteryBanks: array<string>, maxActiveBatteries: int) : int64 =
    let mutable sum = 0L

    for batteryBank in batteryBanks do
        let batteryCount = batteryBank.Length

        let batteryJoltages =
            batteryBank |> Seq.map (fun c -> int c - int '0') |> Seq.toArray

        let mutable startIndex = 0
        let activeBatteries = Array.zeroCreate<int64> (maxActiveBatteries)

        for activeIndex in [ 0 .. (maxActiveBatteries - 1) ] do
            let parts = batteryJoltages[batteryCount - (batteryCount - startIndex) ..]
            let mutable maxJoltage = parts[0]
            let mutable maxIndex = 0

            let maxAllowedIndex = parts.Length - maxActiveBatteries + activeIndex
            for i in [ 1 .. parts.Length - 1 ] do
                if parts[i] > maxJoltage && i <= maxAllowedIndex then
                    maxJoltage <- parts[i]
                    maxIndex <- i

            startIndex <- startIndex + (maxIndex + 1)
            activeBatteries[activeIndex] <- maxJoltage

        let mutable result = 0L

        for v in activeBatteries do
            result <- result * 10L + int64 v

        sum <- sum + result

    sum
