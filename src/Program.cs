#define _USE_MATH_DEFINES
#include <iostream>
#include <iomanip>  // 用于设置输出精度
#include <limits>   // 用于清除输入缓冲区
#include <cmath>    // 用于数学计算（如圆面积）

// 形状基类
class Shape {
public:
    // 纯虚函数，计算面积（平方厘米）
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
    double sideLength;  // 边长（厘米）

public:
    // 构造函数
    Square(double side = 0.0) : sideLength(side) {}
    
    // 设置边长（根据单位转换）
    void setSideLength(double side, int unitChoice) {
        if (side > 0) {
            sideLength = (unitChoice == 2) ? inchesToCentimeters(side) : side;
        }
    }
    
    // 获取边长（厘米）
    double getSideLength() const {
        return sideLength;
    }
    
    // 实现面积计算：边长 × 边长（平方厘米）
    double calculateArea() const override {
        return sideLength * sideLength;
    }
    
    // 从用户输入获取边长（考虑单位）
    void inputSideLength(int unitChoice) {
        double input;
        while (true) {
            std::cout << "请输入正方形的边长：";
            if (std::cin >> input && input > 0) {
                setSideLength(input, unitChoice);
                break; // 输入有效，退出循环
            } else {
                // 清除错误状态并处理无效输入
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
    }
};

// 长方形子类
class Rectangle : public Shape {
private:
    double length;  // 长度（厘米）
    double width;   // 宽度（厘米）

public:
    // 构造函数
    Rectangle(double len = 0.0, double wid = 0.0) : length(len), width(wid) {}
    
    // 设置长和宽（根据单位转换）
    void setDimensions(double len, double wid, int unitChoice) {
        if (len > 0 && wid > 0) {
            length = (unitChoice == 2) ? inchesToCentimeters(len) : len;
            width = (unitChoice == 2) ? inchesToCentimeters(wid) : wid;
        }
    }
    
    // 获取长度（厘米）
    double getLength() const {
        return length;
    }
    
    // 获取宽度（厘米）
    double getWidth() const {
        return width;
    }
    
    // 实现面积计算：长 × 宽（平方厘米）
    double calculateArea() const override {
        return length * width;
    }
    
    // 从用户输入获取长和宽（考虑单位）
    void inputDimensions(int unitChoice) {
        double inputLength, inputWidth;
        
        // 输入长度
        while (true) {
            std::cout << "请输入长方形的长度：";
            if (std::cin >> inputLength && inputLength > 0) {
                break;
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
        
        // 输入宽度
        while (true) {
            std::cout << "请输入长方形的宽度：";
            if (std::cin >> inputWidth && inputWidth > 0) {
                setDimensions(inputLength, inputWidth, unitChoice);
                break;
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
    }
};

// 三角形子类
class Triangle : public Shape {
private:
    double base;    // 底（厘米）
    double height;  // 高（厘米）

public:
    // 构造函数
    Triangle(double b = 0.0, double h = 0.0) : base(b), height(h) {}
    
    // 设置底和高（根据单位转换）
    void setDimensions(double b, double h, int unitChoice) {
        if (b > 0 && h > 0) {
            base = (unitChoice == 2) ? inchesToCentimeters(b) : b;
            height = (unitChoice == 2) ? inchesToCentimeters(h) : h;
        }
    }
    
    // 获取底（厘米）
    double getBase() const {
        return base;
    }
    
    // 获取高（厘米）
    double getHeight() const {
        return height;
    }
    
    // 实现面积计算：(底 × 高) / 2（平方厘米）
    double calculateArea() const override {
        return (base * height) / 2.0;
    }
    
    // 从用户输入获取底和高（考虑单位）
    void inputDimensions(int unitChoice) {
        double inputBase, inputHeight;
        
        // 输入底
        while (true) {
            std::cout << "请输入三角形的底：";
            if (std::cin >> inputBase && inputBase > 0) {
                break;
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
        
        // 输入高
        while (true) {
            std::cout << "请输入三角形的高：";
            if (std::cin >> inputHeight && inputHeight > 0) {
                setDimensions(inputBase, inputHeight, unitChoice);
                break;
            } else {
                std::cin.clear();
                std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                std::cout << "输入无效！请输入一个正数。" << std::endl;
            }
        }
    }
};

// 圆形子类
class Circle : public Shape {
private:
    double diameter;  // 直径（厘米）

public:
    // 构造函数
    Circle(double d = 0.0) : diameter(d) {}
    
    // 设置直径（根据单位转换）
    void setDiameter(double d, int unitChoice) {
        if (d > 0) {
            diameter = (unitChoice == 2) ? inchesToCentimeters(d) : d;
        }
    }
    
    // 获取直径（厘米）
    double getDiameter() const {
        return diameter;
    }
    
    // 实现面积计算：π × (直径/2)²（平方厘米）
    double calculateArea() const override {
        double radius = diameter / 2.0;
        return M_PI * radius * radius;
    }
    
    // 从用户输入获取直径（考虑单位）
    void inputDiameter(int unitChoice) {
        double input;
        while (true) {
            std::cout << "请输入圆形的直径：";
            if (std::cin >> input && input > 0) {
                setDiameter(input, unitChoice);
                break;
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
    // 设置输出精度为3位小数
    std::cout << std::fixed << std::setprecision(3);
    
    int shapeChoice;
    int unitChoice;
    
    // 选择图形类型
    while (true) {
        std::cout << "\n===== 图形面积计算器 =====" << std::endl;
        std::cout << "请选择图形类型：" << std::endl;
        std::cout << "1. 正方形" << std::endl;
        std::cout << "2. 长方形" << std::endl;
        std::cout << "3. 三角形" << std::endl;
        std::cout << "4. 圆形" << std::endl;
        std::cout << "请输入选项 (1-4)：";
        
        if (std::cin >> shapeChoice && shapeChoice >= 1 && shapeChoice <= 4) {
            break;
        } else {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "输入无效！请输入1到4之间的数字。" << std::endl;
        }
    }
    
    // 选择输入单位
    while (true) {
        std::cout << "\n请选择输入单位：" << std::endl;
        std::cout << "1. 厘米" << std::endl;
        std::cout << "2. 英寸" << std::endl;
        std::cout << "请输入选项 (1-2)：";
        
        if (std::cin >> unitChoice && (unitChoice == 1 || unitChoice == 2)) {
            break;
        } else {
            std::cin.clear();
            std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
            std::cout << "输入无效！请输入1或2。" << std::endl;
        }
    }
    
    // 根据选择的图形进行处理
    switch (shapeChoice) {
        case 1: {
            Square square;
            square.inputSideLength(unitChoice);
            std::cout << "\n===== 计算结果 =====" << std::endl;
            std::cout << "图形类型：正方形" << std::endl;
            std::cout << "边长：" << square.getSideLength() << " 厘米" << std::endl;
            std::cout << "面积：" << square.calculateArea() << " 平方厘米" << std::endl;
            break;
        }
        case 2: {
            Rectangle rectangle;
            rectangle.inputDimensions(unitChoice);
            std::cout << "\n===== 计算结果 =====" << std::endl;
            std::cout << "图形类型：长方形" << std::endl;
            std::cout << "尺寸：" << rectangle.getLength() << " × " 
                      << rectangle.getWidth() << " 厘米" << std::endl;
            std::cout << "面积：" << rectangle.calculateArea() << " 平方厘米" << std::endl;
            break;
        }
        case 3: {
            Triangle triangle;
            triangle.inputDimensions(unitChoice);
            std::cout << "\n===== 计算结果 =====" << std::endl;
            std::cout << "图形类型：三角形" << std::endl;
            std::cout << "底：" << triangle.getBase() << " 厘米，高：" 
                      << triangle.getHeight() << " 厘米" << std::endl;
            std::cout << "面积：" << triangle.calculateArea() << " 平方厘米" << std::endl;
            break;
        }
        case 4: {
            Circle circle;
            circle.inputDiameter(unitChoice);
            std::cout << "\n===== 计算结果 =====" << std::endl;
            std::cout << "图形类型：圆形" << std::endl;
            std::cout << "直径：" << circle.getDiameter() << " 厘米" << std::endl;
            std::cout << "面积：" << circle.calculateArea() << " 平方厘米" << std::endl;
            break;
        }
    }
    
    return 0;
}
