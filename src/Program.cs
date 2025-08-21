Console.WriteLine("Hello Git")
那我3

一点不会那个

我选2

我选4

class Shape:
    def area(self):
        """计算面积的抽象方法，子类需要实现"""
        raise NotImplementedError("子类必须实现area()方法")
    
    def inches_to_cm(self, value):
        """将英寸转换为厘米（1英寸 = 2.54厘米）"""
        return value * 2.54


# 正方形子类
class Square(Shape):
    def __init__(self, side_length_inches):
        """初始化正方形，边长以英寸为单位"""
        self.side_length = side_length_inches  # 保存英寸单位的边长
    
    def area(self):
        """计算正方形面积（平方厘米）"""
        # 先将边长转换为厘米，再计算面积
        side_in_cm = self.inches_to_cm(self.side_length)
        return side_in_cm **2
    
    def get_side_length_cm(self):
        """获取以厘米为单位的边长"""
        return self.inches_to_cm(self.side_length)


# 长方形子类
class Rectangle(Shape):
    def __init__(self, length_inches, width_inches):
        """初始化长方形，长和宽以英寸为单位"""
        self.length = length_inches   # 保存英寸单位的长度
        self.width = width_inches     # 保存英寸单位的宽度
    
    def area(self):
        """计算长方形面积（平方厘米）"""
        # 先将长和宽转换为厘米，再计算面积
        length_in_cm = self.inches_to_cm(self.length)
        width_in_cm = self.inches_to_cm(self.width)
        return length_in_cm * width_in_cm
    
    def get_dimensions_cm(self):
        """获取以厘米为单位的长和宽"""
        return (self.inches_to_cm(self.length), self.inches_to_cm(self.width))


# 示例用法
if __name__ == "__main__":
    # 创建正方形实例（边长为5英寸）
    square = Square(5)
    print(f"正方形边长（英寸）: {square.side_length}")
    print(f"正方形边长（厘米）: {square.get_side_length_cm()}")
    print(f"正方形面积（平方厘米）: {square.area()}\n")
    
    # 创建长方形实例（长10英寸，宽6英寸）
    rectangle = Rectangle(10, 6)
    print(f"长方形长和宽（英寸）: {rectangle.length}, {rectangle.width}")
    print(f"长方形长和宽（厘米）: {rectangle.get_dimensions_cm()}")
    print(f"长方形面积（平方厘米）: {rectangle.area()}")
