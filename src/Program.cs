Console.WriteLine("Hello Git")
#include <iostream>

// 形状基类
class Shape {
public:
    // 纯虚函数，计算面积
    virtual double calculateArea() const = 0;
    
    // 静态方法：英寸转换为厘米（1英寸 = 2.54厘米）
    static double inchesToCentimeters(double inches) {
        return inches * 2.54;
    }
    
    // 虚析构函数
    virtual ~Shape() = default;
};

// 正方形子类
class Square : public Shape {
private:
    double sideLength;  // 边长（英寸）

public:
    // 构造函数
    Square(double side) : sideLength(side) {}
    
    // 设置边长
    void setSideLength(double side) {
        sideLength = side;
    }
    
    // 获取边长（英寸）
    double getSideLengthInches() const {
        return sideLength;
    }
    
    // 获取边长（厘米）
    double getSideLengthCentimeters() const {
        return inchesToCentimeters(sideLength);
    }
    
    // 实现面积计算：边长 × 边长
    double calculateArea() const override {
        return sideLength * sideLength;
    }
};

// 长方形子类
class Rectangle : public Shape {
private:
    double length;  // 长度（英寸）
    double width;   // 宽度（英寸）

public:
    // 构造函数
    Rectangle(double len, double wid) : length(len), width(wid) {}
    
    // 设置长和宽
    void setDimensions(double len, double wid) {
        length = len;
        width = wid;
    }
    
    // 获取长度（英寸）
    double getLengthInches() const {
        return length;
    }
    
    // 获取宽度（英寸）
    double getWidthInches() const {
        return width;
    }
    
    // 获取长度（厘米）
    double getLengthCentimeters() const {
        return inchesToCentimeters(length);
    }
    
    // 获取宽度（厘米）
    double getWidthCentimeters() const {
        return inchesToCentimeters(width);
    }
    
    // 实现面积计算：长 × 宽
    double calculateArea() const override {
        return length * width;
    }
};

// 示例用法
int main() {
    // 创建正方形对象（边长5英寸）
    Square square(5.0);
    std::cout << "正方形边长: " << square.getSideLengthInches() << "英寸 (" 
              << square.getSideLengthCentimeters() << "厘米)" << std::endl;
    std::cout << "正方形面积: " << square.calculateArea() << "平方英寸" << std::endl;
    
    // 创建长方形对象（长6英寸，宽4英寸）
    Rectangle rectangle(6.0, 4.0);
    std::cout << "长方形尺寸: " << rectangle.getLengthInches() << "x" << rectangle.getWidthInches() 
              << "英寸 (" << rectangle.getLengthCentimeters() << "x" << rectangle.getWidthCentimeters() 
              << "厘米)" << std::endl;
    std::cout << "长方形面积: " << rectangle.calculateArea() << "平方英寸" << std::endl;
    
    return 0;
}
    
