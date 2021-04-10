# CodingChallenges

## General Rules

Weekly challenges of general coding skills
The average, maximum and minimum of the runtime is compared and the winner has won!


<details>
<summary>
<strong> Kth Maximum Rules 19.03. - 27.03. </strong>
</summary>  
Find the kth maximum of a list of n elements

if n  is 0 the solution is -1000
if k is bigger than n find the minimum of the list
</details>
<details>
<summary>
<strong> Sightseeing (Google Kickstart 2017 - Round D - Problem 1) 27.3. - 3.4. </strong>
</summary>
When you travel, you like to spend time sightseeing in as many cities as possible, but sometimes you might not be able to because you need to catch the bus to the next city. To maximize your travel enjoyment, you decide to write a program to optimize your schedule.

You begin at city 1 at time 0 and plan to travel to cities 2 to N in ascending order, visiting every city. There is a bus service from every city i to the next city i + 1. The i-th bus service runs on a schedule that is specified by 3 integers: Si, Fi and Di, the start time, frequency and ride duration. Formally, this means that there is a bus leaving from city i at all times Si + xFi, where x is an integer and x ≥ 0, and the bus takes Di time to reach city i + 1.

At each city between 1 and N - 1, inclusive, you can decide to spend Ts time sightseeing before waiting for the next bus, or you can immediately wait for the next bus. You cannot go sightseeing multiple times in the same city. You may assume that boarding and leaving buses takes no time. You must arrive at city N by time Tf at the latest. (Note that you cannot go sightseeing in city N, even if you arrive early. There's nothing to see there!)

What is the maximum number of cities you can go sightseeing in?

### Input
The input starts with one line containing one integer T, which is the number of test cases. T test cases follow.

Each test case begins with a line containing 3 integers, N, Ts and Tf, representing the number of cities, the time taken for sightseeing in any city, and the latest time you can arrive in city N.

This is followed by N - 1 lines. On the i-th line, there are 3 integers, Si, Fi and Di, indicating the start time, frequency, and duration of buses travelling from city i to city i + 1.

### Output
For each test case, output one line containing Case #x: y, where x is the test case number (starting from 1) and y is the maximum number of cities you can go sightseeing in such that you can still arrive at city N by time Tf at the latest. If it is impossible to arrive at city N by time Tf, output Case #x: IMPOSSIBLE.

### Limits
1 ≤ T ≤ 100.
Time limit: 20 seconds per test set.
Memory limit: 1GB.


#### Small dataset (Test set 1 - Visible)
2 ≤ N ≤ 16.
1 ≤ Si ≤ 5000.
1 ≤ Fi ≤ 5000.
1 ≤ Di ≤ 5000.
1 ≤ Ts ≤ 5000.
1 ≤ Tf ≤ 5000.


#### Large dataset (Test set 2 - Hidden)
2 ≤ N ≤ 2000.
1 ≤ Si ≤ 109.
1 ≤ Fi ≤ 109.
1 ≤ Di ≤ 109.
1 ≤ Ts ≤ 109.
1 ≤ Tf ≤ 109.

### Sample
**Input**
4
4 3 12
3 2 1
6 2 2
1 3 2
3 2 30
1 2 27
3 2 1
4 1 11
2 1 2
4 1 5
8 2 2
5 10 5000
14 27 31
27 11 44
30 8 20
2000 4000 3

**Output:**
Case #1: 2
Case #2: 0
Case #3: IMPOSSIBLE
Case #4: 4

In the first test case, you can go sightseeing in city 1, catching the bus leaving at time 3 and arriving at time 4. You can go sightseeing in city 2, leaving on the bus at time 8. When you arrive in city 3 at time 10 you immediately board the next bus and arrive in city 4 just in time at time 12.
</details>
<details>
<summary>
<strong> Was für ne Schiebung! 03.4.- 10.4.  </strong>
</summary>
Aufgabe finde eine Verschiebung v für die gilt |v| minimal und ex eine Quersumme q von den Spalten für M, so dass |q - k| miminal.

#### Input: Matrix M nxm, int k

#### Output: int[] v

### Beispiel:

für k = 1,3,7,20

(1  4  5) (0)   (4  5  1) (1) (5  1  4) (2)
(2  8  3) (0)   (2  8  3) (0) (2  8  3) (0)
|3  12 8|       |6  13 4|     |7  9  7|

(1  4  5) (0)   (4  5  1) (1) (5  1  4) (2)
(8  3  2) (1)   (8  3  2) (1) (8  3  2) (1)
|9  7  7|       |12 8  3|     |13 4  6|

(1  4  5) (0)   (4  5  1) (1) (5  1  4) (2)
(3  2  8) (2)   (3  2  8) (2) (3  2  8) (2)
|4  6  13|      |7  7  9|     |8  3  12|

Lösungen:

1:  (0, 0)
3:  (0, 0)
7:  (0, 1)
20: (1, 0)
</details>
<details open>
<summary>
<strong> Vollständige Klammerung 10.4. - 17.4. </strong>
</summary>
Gegeben eine logische Formel als String. Gesucht ist die vollständige Klammerung der Formel.  
logische Operatoren: AND, OR, !, XOR, =>, <=>.  

Beispiel Formel: A AND B OR !(C OR D) => F  
Lösung: ((((A) AND (B)) OR (!(((C) OR (D))))) => (F))  

_ OR _ = (( _ ) OR ( _ ))  
! _  = (! (_))  

</details>
