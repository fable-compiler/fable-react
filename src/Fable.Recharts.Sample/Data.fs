module Data

open Fable.Core

type [<Pojo>] Data =
    { name: string; uv: int; pv: int; amt: int }

type [<Pojo>] Data01 =
    { day: string; weather: string }

type [<Pojo>] RangeData =
    { day: string; temperature: int * int }

let data =
    [| { name = "Page A"; uv = 4000; pv = 2400; amt = 2400 }
       { name = "Page B"; uv = 3000; pv = 1398; amt = 2210 }
       { name = "Page C"; uv = 2000; pv = 9800; amt = 2290 }
       { name = "Page D"; uv = 2780; pv = 3908; amt = 2000 }
       { name = "Page E"; uv = 1890; pv = 4800; amt = 2181 }
       { name = "Page F"; uv = 2390; pv = 3800; amt = 2500 }
       { name = "Page G"; uv = 3490; pv = 4300; amt = 2100 }
    |]

let data01 =
    [| { day = "05-01"; weather = "sunny" }
       { day = "05-02"; weather = "sunny" }
       { day = "05-03"; weather = "cloudy" }
       { day = "05-04"; weather = "rain" }
       { day = "05-05"; weather = "rain" }
       { day = "05-06"; weather = "cloudy" }
       { day = "05-07"; weather = "cloudy" }
       { day = "05-08"; weather = "sunny" }
       { day = "05-09"; weather = "sunny" }
    |]

let data02 =
    [| { name = "Page A"; uv = 4000; pv = 2400; amt = 2400 }
       { name = "Page B"; uv = 3000; pv = 1398; amt = 2210 }
       { name = "Page C"; uv = 2000; pv = 9800; amt = 2290 }
       { name = "Page D"; uv = 2780; pv = 3908; amt = 2000 }
       { name = "Page E"; uv = 1890; pv = 4800; amt = 2181 }
    |]

let rangeData =
    [| { day = "05-01"; temperature = (-1, 10) }
       { day = "05-02"; temperature = (2, 15) }
       { day = "05-03"; temperature = (3, 12) }
       { day = "05-04"; temperature = (4, 12) }
       { day = "05-05"; temperature = (12, 16) }
       { day = "05-06"; temperature = (5, 16) }
       { day = "05-07"; temperature = (3, 12) }
       { day = "05-08"; temperature = (0, 8) }
       { day = "05-09"; temperature = (-3, 5) }
   |]
