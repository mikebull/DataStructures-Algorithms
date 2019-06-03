require_relative 'graph'

graph = Graph.new

graph.add_vertex(1)
graph.add_vertex(2)
graph.add_vertex(3)
graph.add_vertex(4)
graph.add_vertex(5)
graph.add_vertex(6)
graph.add_vertex(7)

graph.add_edge(1, 2)
graph.add_edge(1, 3)
graph.add_edge(2, 4)
graph.add_edge(3, 5)
graph.add_edge(4, 5)
graph.add_edge(5, 6)
graph.add_edge(1, 7)
graph.add_edge(6, 7)

graph.breadth_first_search(1, 4)

# graph.depth_first_search_iterative(1, 4)
# graph.depth_first_search_recursive(1, 4)

graph.list