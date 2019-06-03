require 'set'

class Graph
  def initialize()
    @adjacency_list = Hash.new { |h, k| h[k] = Set.new }
  end

  def add_vertex(index)
    @adjacency_list[index]
  end
  
  def add_edge(v, e)
    @adjacency_list[v].add(e)
    @adjacency_list[e].add(v)
  end
  
  def remove_vertex(index)
    @adjacency_list.delete(index)
  end
  
  def remove_edge(v, e)
    @adjacency_list[v].delete(e)
    @adjacency_list[e].delete(v)
  end
  
  def adjacent?(v1, v2)
    @adjacency_list[v1].include?(v2)
  end
  
  def adjacent_vertices(v)
    @adjacency_list[v]
  end

  def list
    @adjacency_list.each do |vertex, edges|      
      puts "Vertex: #{vertex}. Edges: #{edges.to_a.join(', ')}"
    end
  end

  def breadth_first_search(start, finish)
    visited = []
    queue = []

    visited[start] = true
    queue.push(start)

    while !queue.empty?
      source = queue.shift
      puts "Start at #{source}"

      @adjacency_list[source].each do |vertex|
        unless visited[vertex]
          if vertex.eql?(finish)
            puts "Go from #{source} to #{vertex}."
            puts "Found finish!"
            return
          end

          puts "Go from #{source} to #{vertex}."

          visited[vertex] = true
          queue.push(vertex)
        end
      end
    end
  end

  def depth_first_search_iterative(start, finish)
    @parent = []

    puts "Start at #{start}"

    stack = []

    @adjacency_list[start].each do |vertex|
      if vertex.eql?(finish)
        puts "Found finish!"
        return
      end

      puts "Go from #{start} to #{vertex}"

      unless @parent.include?(vertex)
        stack.push(vertex)
        set_parent(vertex, start)
        while !stack.empty?
          @adjacency_list[vertex].each do |neighbour|
            if neighbour.eql?(finish)
              puts "Go from #{vertex} to #{neighbour}"
              puts "Found finish!"
              return
            end
      
            unless @parent.include?(neighbour)
              puts "Go from #{vertex} to #{neighbour}"
              
              set_parent(vertex, neighbour)
              vertex = stack.pop
              stack.push(neighbour)
            end
          end
        end
      end
    end
  end

  def depth_first_search_recursive(start, finish)
    @parent = []

    puts "Start at #{start}"

    @adjacency_list[start].each do |vertex|
      if vertex.eql?(finish)
        puts "Found finish!"
        return
      end

      puts "Go from #{start} to #{vertex}"

      unless @parent.include?(vertex)
        set_parent(vertex, start)
        depth_first_search_visit(vertex, finish)
      end
    end
  end

  private

  def depth_first_search_visit(source, finish)
    @adjacency_list[source].each do |vertex|
      if vertex.eql?(finish)
        puts "Go from #{source} to #{vertex}"
        puts "Found finish!"
        return
      end

      unless @parent.include?(vertex)
        puts "Go from #{source} to #{vertex}"

        set_parent(source, vertex)
        depth_first_search_visit(vertex, finish)
      end
    end
  end

  def set_parent(source, destination=nil)
    @parent[source] = destination unless source.nil?
    @parent[destination] = source unless destination.nil?
  end
end