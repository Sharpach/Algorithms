# graph = [1, 2, 3, 4, 5, 6]
# adjacents = [[2, 3], [1, 3, 4, 4], [1, 2, 4, 5], [2, 2, 3, 5, 6], [3, 4, 6], [4, 5]]
# weights = [[7, 8], [7, 3, 6, 8], [8, 3, 4, 3], [6, 8, 4, 2, 5], [3, 2, 2], [5, 2]]

# Q's graph
graph = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i']

adjacents = [['b', 'h'], ['h', 'c'],
             ['d', 'i', 'f'], ['e', 'f'],
             ['f'], ['g'], ['i', 'h'],
             ['i'], []]

weights = [[4, 8], [11, 8],
           [7, 2, 4], [6, 14],
           [10], [2], [6, 1],
           [7], []]


visited = []
parent = [0] * len(graph)
cost = [-1] * len(graph)

# Element to start from
x = 'a'

# Until all Nodes are visited
for _ in range(len(graph)):
    visited.append(x)
    # print(f"Vertex = {x}")
    index_x = graph.index(x)
    for i in range(len(adjacents[index_x])):

        if adjacents[index_x][i] not in visited:
            index_adj = graph.index(adjacents[index_x][i])

            # Cost Update
            if cost[index_adj] == -1 or cost[index_adj] > weights[index_x][i] + cost[index_x]:
                if cost[index_x] != -1:
                    cost[index_adj] = cost[index_x] + weights[index_x][i]
                    parent[index_adj] = x
                else:
                    cost[index_adj] = weights[index_x][i]
                    parent[index_adj] = x

            else:
                pass
        # print(f"Cost = {cost}")
        # print(f"Parent{parent}")
        # print("\n")

    # Minimum Value of list Cost from non-visited nodes
    min = -1
    for i in range(len(cost)):
        if graph[i] in visited or cost[i] == -1:
            pass
        elif min == -1 or min > cost[i]:
            min = cost[i]
            index_min = i

    # Shifting to Next Node
    x = graph[index_min]

# print("\n")
# print("Visited List {:>20}".format(str(visited)))
# print("Final Cost {:>23}".format(str(cost)))
# print("Parents {:>25}".format(str(parent)))
cost[0] = 0
print("-------------------------------\n")
print("Shortest Path - Dijkstra\n")
for i in range(1, len(cost)):
    print(f"Cost a to {graph[i]} = {cost[i]}")
print("\n-----------------------------")