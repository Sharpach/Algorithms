from typing import Optional


def binary_search(arr: list, num: int) -> Optional[int]:
    smallest = 0
    biggest = len(arr) - 1

    while smallest <= biggest:
        middle = (smallest + biggest) // 2
        guess = arr[middle]

        if guess == num:
            return middle
        if guess > num:
            biggest = middle - 1
        else:
            smallest = middle + 1
    return None
