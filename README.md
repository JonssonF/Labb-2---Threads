# Labb 2 - Threads - Advanced.NET

# 🏎️ Console Car Racing Simulator

This is a multithreaded car racing simulator built as a console application in C#. The goal of the lab is to simulate a race between two or more cars, where each car runs on its own thread and can encounter random obstacles along the way. The first car to complete a 5 km track wins the race!

## 🚀 Features

- Each car is represented as an object with a driver and a name.
- Cars race over a 5 km distance.
- All cars start at 120 km/h without acceleration.
- Each car runs in a separate thread, simulating real-time competition.
- Random events can happen during the race to slow down or stop a car.
- Real-time status updates available on demand.
- Console output for race updates, events, and winner announcements.

## 🧩 Random Events

Every 10 seconds, each car has a chance to encounter a random event. Only one event can happen at a time per car.

| Event                   | Probability | Effect                                      |
|------------------------|-------------|---------------------------------------------|
| Out of fuel            | 1/50        | Refuels – stops for 15 seconds              |
| Bananapeel             | 2/50        | Looses control – stops for 10 seconds       |
| Bird on windshield     | 5/50        | Cleans windshield – stops for 5 seconds     |
| Engine malfunction     | 10/50       | Reduces speed by 1 km/h permanently         |


## 📈 Console Output

- ⏱️ All cars start at the same time, and a message is printed.
- ⚠️ If a car encounters a problem, the console will show which car was affected and what happened.
- 🏁 When a car reaches the finish line, a message is printed. The first car is declared the winner.
- 🔄 At any time, the user can press **Enter** or type **"status"** to get a real-time update on the race progress, showing:
  - How far each car has traveled
  - Each car’s current speed
  - And elapsed time of the race

