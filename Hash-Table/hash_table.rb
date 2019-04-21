class HashTable
  # Implementation of Hash Table with Linear Probing
  def initialize(size = 10)
    @size = size
    @items = Array.new(size)
  end

  def add(key, value)
    hashed_key = hash(key)
    if exists?(key)
      pointer = hashed_key + 1
      puts "Collision at #{hashed_key}. Pointer set to #{pointer}"
      while hashed_key != pointer
        if @items[pointer].nil?
          @items[pointer] = [key, value]
          break
        elsif pointer >= @size
          puts "Pointer set to zero"
          pointer = 0
        else
          pointer += 1
          puts "New pointer at #{pointer}"
        end
      end
      throw "Hash Table full" if hashed_key.eql?(pointer)
    else
      @items[hashed_key] = [key,value]
    end
  end

  def get(key)
    hashed_key = hash(key)
    if exists?(key)
      value = @items[hashed_key].last
      key_in_hash = @items[hashed_key].first

      return value if key_in_hash == key && value != -1

      pointer = hashed_key + 1
      puts "Pointer set to #{pointer}"
      while hashed_key != pointer
        return nil if @items[pointer].nil?
        
        value = @items[pointer].last
        key_in_hash = @items[pointer].first

        if key_in_hash == key && value != -1
          puts "Keys: #{key_in_hash} - #{key}"
          puts "Value found at #{pointer}"
          return value
        end

        if pointer == @size
          puts "Pointer set to zero"
          pointer = 0
        else
          return nil if value == nil
          pointer += 1
          puts "New pointer at #{pointer}"
        end
      end
    end
    puts "Nothing found"
    nil
  end

  def remove(key)
    hashed_key = hash(key)
    @items[hashed_key] = [key, -1]
  end

  def exists?(key)
    hashed_key = hash(key)
    
    item = @items[hashed_key]

    return false if item == nil
    return item.last != -1
  end

  def list
    @items.each_with_index do |item, index|
      puts "(#{index}, #{item})"
    end
  end

  private

  def hash(key)
    key.hash % @size
  end
end