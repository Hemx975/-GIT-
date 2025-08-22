Console.WriteLine("Hello Git")
#include <iostream>
#include <iomanip> // 用于设置输出精度
#include <limits>  // 用于清除输入缓冲区

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
    Square(double side = 0.0) : sideLength(side) {}
    
    // 设置边长
    void setSideLength(double side) {
        if (side > 0) {
            sideLength = side;
        }
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
    
    // 从用户输入获取边长，修复了非数字输入的处理
    void inputSideLength() {
        while (true) {
            std::cout << "请输入正方形的边长（英寸）: ";
            if (std::cin >> sideLength && sideLength > 0) {
                break; // 输入有效，退出循环
            } else {
                // 清除错误状态
                std::cin.clear();
                // 忽略缓冲区中剩余的字符
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
    }
};

// 长方形子类
class Rectangle : public Shape {
private:
    double length;  // 长度（英寸）
    double width;   // 宽度（英寸）

public:
    // 构造函数
    Rectangle(double len = 0.0, double wid = 0.0) : length(len), width(wid) {}
    
    // 设置长和宽，添加了有效性检查
    void setDimensions(double len, double wid) {
        if (len > 0 && wid > 0) {
            length = len;
            width = wid;
        }
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
    
    // 从用户输入获取长和宽，修复了非数字输入的处理
    void inputDimensions() {
        // 输入长度
        while (true) {
            std::cout << "请输入长方形的长度（英寸）: ";
            if (std::cin >> length && length > 0) {
                break; // 输入有效，退出循环
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
        
        // 输入宽度
        while (true) {
            std::cout << "请输入长方形的宽度（英寸）: ";
            if (std::cin >> width && width > 0) {
                break; // 输入有效，退出循环
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
    }
};

// 主函数
int main() {
    // 设置输出精度
    std::cout << std::fixed << std::setprecision(2);
    
    // 处理正方形
    Square square;
    square.inputSideLength();
    std::cout << "\n正方形信息:" << std::endl;
    std::cout << "边长: " << square.getSideLengthInches() << "英寸 (" 
              << square.getSideLengthCentimeters() << "厘米)" << std::endl;
    std::cout << "面积: " << square.calculateArea() << "平方英寸" << std::endl;
    
    // 处理长方形
    Rectangle rectangle;
    rectangle.inputDimensions();
    std::cout << "\n长方形信息:" << std::endl;
    std::cout << "尺寸: " << rectangle.getLengthInches() << "x" << rectangle.getWidthInches() 
              << "英寸 (" << rectangle.getLengthCentimeters() << "x" << rectangle.getWidthCentimeters() 
              << "厘米)" << std::endl;
    std::cout << "面积: " << rectangle.calculateArea() << "平方英寸" << std::endl;
    
    return 0;
}
