




# 设计模式 

设计模式（Design pattern）代表了最佳的实践，通常被有经验的面向对象的软件开发人员所采用。设计模式是软件开发人员在软件开发过程中面临的一般问题的解决方案。这些解决方案是众多软件开发人员经过相当长的一段时间的试验和错误总结出来的。

设计模式是一套被反复使用的、多数人知晓的、经过分类编目的、代码设计经验的总结。使用设计模式是为了重用代码、让代码更容易被他人理解、保证代码可靠性。 毫无疑问，设计模式于己于他人于系统都是多赢的，设计模式使代码编制真正工程化，设计模式是软件工程的基石，如同大厦的一块块砖石一样。项目中合理地运用设计模式可以完美地解决很多问题，每种模式在现实中都有相应的原理来与之对应，每种模式都描述了一个在我们周围不断重复发生的问题，以及该问题的核心解决方案，这也是设计模式能被广泛应用的原因。

`什么是高内聚？模块内部元素具有相同特点的相似程度。提供了更好的程序可靠性，可读性`

`什么是低耦合？指的是模块之间的依赖程度。提供了更好的程序可扩展与可复用性`

[深入理解设计模式（六）：原型模式 - 一指流砂~ - 博客园 (cnblogs.com)](https://www.cnblogs.com/xuwendong/p/9768441.html)

[设计模式 | 菜鸟教程 (runoob.com)](https://www.runoob.com/design-pattern/design-pattern-tutorial.html)

[设计模式目录：22种设计模式 (refactoringguru.cn)](https://refactoringguru.cn/design-patterns/catalog)

## 设计的原则

### 单一职责原则SRP(Single Responsibilities Principle)

**（专人做专事）**

定义：一个类只有一个发生变化原因，应该只有一个引起类受更的原因.。

指出一个类或方法应该只有一个责任，即一个类或方法只负责一项功能，可以通过将每个类或方法的职责限制在一个特定的领域内来实现单一职责原则。

1. 比如：当一个类只有在添加的时候才会触动类的改变，符合单一职责原则。
2. 或者：当一个类中只有一个方法会存在修改的情况从而触动类的改变，且不再在类中新增方法时，也符合单一职责原则。

**好处：**

1. 降低类的复杂性，一个模块只有一个职责，提高系统的可扩展和可维护性。
2. 提高代码的可读性，提高系统的可维护性。
3. 降低变更引起的风险。变更是必然的，如果单一职责做得好，当修改一个功能的时候可以显著的降低对另一个功能的影响。
4. 避免类的膨胀，臃肿。

### 开闭原则OCP（Open Close Principle）

**（热插拔，类似USB）**

定义：**对扩展开放，对修改关闭**。在程序需要进行拓展的时候，不能去修改原有的代码，实现一个热插拔的效果。简言之，是为了使程序的扩展性好，易于维护和升级。想要达到这样的效果，我们需要使用接口和抽象类。不在修改源代码的情况下，完成系统扩展。

​    **好处：**

1. 降低维护成本：开闭原则能够避免在修改现有代码时引入新的问题，从而降低了维护成本。由于新的功能可以通过扩展而不是修改现有代码来实现，所以原有的代码可以保持不变，不会出现错误或者不稳定的情况。
2. 增强扩展性：开闭原则使得新功能可以通过扩展代码而不是修改代码来实现。这样可以减少对现有代码的依赖，增强代码的扩展性。
3. 增强复用性：通过将代码分离成不同的模块，可以提高代码的可复用性。新的功能可以通过组合不同的模块来实现，从而避免了重复编写代码的问题。
4. 提高代码质量：通过遵循开闭原则，可以编写更加稳定、可靠和可读性的代码。这样可以减少代码中的错误和漏洞，提高代码的质量。

总结：

```
面向抽象（接口）编程
通过抽象（接口）封装变化
封装，抽象不是目的，目的是封装变化。
只有把变化封装了，我们的程序，才能做单一、才能做到开闭封闭
```

### **依赖倒转原则DIP（Dependence Inversion Principle）**

**（依赖注入）**

定义：

1. 高层模块不应该依赖低层模块。
2. 抽象不应该依赖细节，细节应该依赖抽象。
3. **【依赖倒转原则】**的本质就是通过抽象（接口或抽象类）使各类或模块的实现彼此独立，互不影响，实现模块间的松耦合。
4. 【依赖倒转原则】是开闭原则的基础，具体内容：针对接口编程，依赖于抽象而不依赖于具体实现。

​    **好处：**

1. 提高系统稳定系统，可维护性。

   解：

   什么是高层模块，什么是低层模块，（高用者）是高层，（被调用者）是低层，这两个模块应该依赖抽象

### **里氏代换原则LSP（Liskov Substitution Principle）**

**（子类可以替换父类）**

定义：里氏代换原则是面向对象设计的基本原则之一。 里氏代换原则中说，任何基类可以出现的地方，子类一定可以出现。LSP 是继承复用的基石，只有当派生类可以替换掉基类，且软件单位的功能不受到影响时，基类才能真正被复用，而派生类也能够在基类的基础上增加新的行为。里氏代换原则是对开闭原则的补充。实现开闭原则的关键步骤就是抽象化，而基类与子类的继承关系就是抽象化的具体实现，所以里氏代换原则是对实现抽象化的具体步骤的规范。

好处：父类可以被子类无缝替换，且原有功能不受任何影响。

![image-20230421184941673](image/image-20230421184941673.png)

### **接口隔离原则ISP（Interface Segregation Principle）**

**（使用多个隔离的接口，比使用单个接口要好）**

定义：

1. 客户端不应该依赖它不需要接口
2. 一个类对另一个类的依赖应该建立在最小接口上。
3. 接口尽量细分，不要在一个接口放很多方法。

好处：

​     单化接口的职责，从而有效地避免接口污染，较少类之间的依赖关系，可以提高灵活性，不同的小接口可以有多种组合

 总结：

​     `接口隔离原则和单一职责原则的关系。`

​     `单一职责原则：一件事件、影响类变化的原因就只有一个。高内聚 （模块内部元素的相似程度）`

​     `接口隔离原则：低耦合  模块之间的依赖程度低`

​    `一个公司分为好多部门，这种可以解析为接口隔离原则，每个部门之间都是低耦合的。`

​    `财务部只做关于财务部的事，不会做洗厕所工作，给老板按摩工作(秘书)。这个可以解析为单一职责原则。`

`根据接口隔离原则拆分接口时，首先必须满足单一职责原则`

### 迪米特原则，**又称最少知道原则**DP（Demeter Principle）

**（类似代理）**

定义：

1.  一个对象应该对其他对象有最少的了解，使得系统功能模块相对独立。创建类的时候要遵守的法则
2. 如果两个类不必彼此直接通信，那么这两个类就不应当发生直接的相互作用。如果其中的一个类需要调用另一个类的某一个方法的话，可以通过第三者转发这个调用。

好处：

​      降低类之间耦合 

```c#
    只和直接朋友通信
    1、成员对象
    2、方法参数
    3、方法返回值
    4、注：出现在局部变量中的类，不是直接朋友
    
    public class TestA
    {
        public void TestMethod(TestB testB /*直接朋友*/)
        {
            TestC testC = new TestC(); //不是直接朋友
        }

        //直接朋友
        private TestD _testD;

        public TestB /*直接朋友*/ GetTestB()
        {
            return null;
        }

        private List<int> list = new List<int>();
    }

    public class TestB
    { }
    public class TestC
    { }
    public class TestD
    { }
```

### **合成复用原则CRP（Composite Reuse Principle）**

定义：合成复用原则是指：尽量使用合成/聚合的方式，而不是使用继承。

Is A  的时候使用继承

has A的时候使用合成  大雁  翅膀

继承的问题：

1. 破坏了系统的封装性，基类发生了改变，子类的实现也会发生改变。
2. 子类如果不需要【**某个方法**】则系统耦合性变高。
3. 继承是静态的，不能在程序运行是发生改变。

![合成](image/image-20230421212408872.png)

组合、聚合、依赖...….是什么?

他们都是类与类之间的关系:**泛化、实现、组合、聚合、关联、依赖**



​                                                                             类图:

![类图解析](image/image-20230421214348959.png)



   泛化：其实就是继承

![image-20230421215217369](image/image-20230421215217369.png)

实现：类与接口的关系，表示类实现接口

![实现](image/image-20230421220253758.png)

组合：组合是整体和部分的关系，部分没有独立的生命周期，组合是把部分作为整体的对象

组合关系，是强拥有的关系，个体/邵分不存在独立的生命周期，个体/部分的生命周期，与整体的生命周期保持一致。

![组合](image/image-20230421221358690.png)



聚合：聚合也是整体与部分的关系，但是个体有独立的生命周期，聚合是把个体对象的指针（引用）作为整体类的属性（弱拥有）

![聚合](image/image-20230421222657821.png)

关联：关联是一种拥有关系，它使一个类知道另一个类的属性和方法（知道关系）

![关联](image/image-20230421223434272.png)

依赖：依赖是一种使用关系

![依赖](image/image-20230421224323976.png)



####                                                                 **设计原则总结**

1. 设计原则是「高内聚、低耦合」的具体落地。
2. 单一职责原则要求在软件系统开发、设计中，一个类只负责一个功能领域的相关职责。
3. 开放封闭原则要求一个软件应该对扩展开放，对修改封闭，即在不修改源代码的情况下，完成系统功能的扩展。
4. 里式替换原则决定了子类可以赋值给父类。
5. 依赖倒置原则要求抽象不应该依赖于细节，细节应该依赖于抽象。要面向接口编程，不要面向实现编程。
6. 迪米特原则要求一个对象尽可能少的与其他对象发生相互作用。
7. 接口隔离原则要求客户端不应该依赖那些他不需要的接口，即将一些大的接口细化成一些小的接口供客户端使用。
8. 合成复用原则要求我们尽量使用对象的组合，而非继承来达到复用的目标。



## UML图

![UML图](image/image-20230425164550125.png)



[面向对象的照妖镜——UML类图绘制指南 - 姜承轩 - 博客园 (cnblogs.com)](https://www.cnblogs.com/green-jcx/p/16769300.html)

[UML 类图教程 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/456759825)

[30分钟学会UML类图 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/109655171)

## 设计模式的类型

 **创建型模式**

   作用于对象的创建，将对象的创建与使用分离

- 单例模式（Singleton Pattern）
- 简单工厂模式（Factory Pattern）
- 工厂方法模式（Factory Method）
- 抽象工厂模式（Abstract Factory Pattern）
- 建造者模式（Builder Pattern）
- 原型模式（Prototype Pattern）

**结构型模式**

   作用于对象和类组装成较大的结构， 并同时保持结构的灵活和高效。“组合优于继承”。

- 适配器模式（Adapter Pattern）
- 桥接模式（Bridge Pattern）
- 过滤器模式（Filter、Criteria Pattern）
- 组合模式（Composite Pattern）
- 装饰器模式（Decorator Pattern）
- 外观模式（Facade Pattern）
- 享元模式（Flyweight Pattern）
- 代理模式（Proxy Pattern）

**行为型模式**

​    作用于类或者对象之间互相协作完成单个对象无法单独完成的任务,以及怎样分配职责。

- 责任链模式（Chain of Responsibility Pattern）

- 命令模式（Command Pattern）

- 解释器模式（Interpreter Pattern）

- 迭代器模式（Iterator Pattern）

- 中介者模式（Mediator Pattern）

- 备忘录模式（Memento Pattern）

- 观察者模式（Observer Pattern）

- 状态模式（State Pattern）

- 空对象模式（Null Object Pattern）

- 策略模式（Strategy Pattern）

- 模板模式（Template Pattern）

- 访问者模式（Visitor Pattern）

  

  

  ![image-20230425215031402](image/image-20230425215031402.png)

  

  ![image-20230425214920438](image/image-20230425214920438.png)

  

##  创建型模式

### 单例模式（Singleton Pattern）

单例模式（Singleton Pattern）是 所以有语言 中最简单的设计模式之一。这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。

这种模式涉及到一个单一的类，该类负责创建自己的对象，同时确保只有单个对象被创建。这个类提供了一种访问其唯一的对象的方式，可以直接访问，不需要实例化该类的对象。

注：

1、单例类只能有一个实例。

2、单例类必须自己创建自己的唯一实例。

3、单例类必须给所有其他对象提供这一实例。

**介绍**

**意图：**单例模式能保证一个类只有一个实例，并提供一个访问该实例的全局点。（违法单一职责，解决两个问题）

**主要解决：**一个全局使用的类频繁地创建与销毁。

**何时使用：**当您想控制实例数目，节省系统资源的时候。

**关键代码：**

1、构造函数是私有的

2、创建一个唯一的对象

单例模式几种介绍：

1、饿汉式

  描述： 这种对象还没有被调用就在内存中，造成资源浪费。

  优点：没有加锁，执行效率会提高。

   缺点：浪费内存。

2、懒汉式，线程不安全

  描述：当你需要对象的时候，我再给你创建对象，不会造成内存浪费。

  优点：需要的时候创建，不会造成内存浪费。

  缺点：线程不安全。

  实例


```c#
 public class LazyManSigle
    {
        private static LazyManSigle _lazyManSigle;
        private LazyManSigle()
        {
        }   
     
        public static LazyManSigle GetInstance()
        {
        //没有创建，就创建，假如创建了，就返回
        if (_lazyManSigle == null)
        {
            _lazyManSigle = new LazyManSigle();
        }
        return _lazyManSigle;
    }
}
```
3、懒汉式，线程安全（双重检查，加锁）

  描述：当你需要对象的时候，我再给你创建对象，不会造成内存浪费，双if加锁检查使用对象线程安程，多线程下也只有创建一个实例。

  优点：需要的时候创建，不会造成内存浪费，并线程安全。

  缺点：线程安全，加锁会影响效率。

   但是在反射下可以被破坏的。

  实例


```c#
 public class LazyManSigle
{
    private static LazyManSigle _lazyManSigle;
    private static object _lock = new object();
    private LazyManSigle()
    {
    }
   public static LazyManSigle GetInstance()
    {
        //没有创建，就创建，假如创建了，就返回
        //先判断 if 加锁 然后判断，可以提升一点性能，不是一直锁等待
        if (_lazyManSigle == null)
        {
            //加锁
            lock (_lock)
            {

                if (_lazyManSigle == null)
                {
                    _lazyManSigle = new LazyManSigle();
                    Console.WriteLine("我被创建了");
                }

            }

        }
        return _lazyManSigle;
    }
}
```
4、静态内部类

  描述：当你需要对象的时候，我再给你创建对象，也线程安全的。

  优点：需要的时候创建，不会造成内存浪费，并线程安全，不用自己加锁。

  实例  

```c#
    public class InnerSignleton
    {
        private static class InnerClassHolder
        {
            public static InnerSignleton _singleton = new InnerSignleton();
        }
        private InnerSignleton()
        {
           
        }
        public static InnerSignleton GetInstance()
        {
            return InnerClassHolder._singleton;
        }

    }
```

5、可以使用c#Lazy类

[C# 使用Lazy 懒加载 - WmW - 博客园 (cnblogs.com)](https://www.cnblogs.com/luludongxu/p/15244159.html)

### 简单工厂模式（Factory Pattern）

1. 简单工厂模式，又叫静态工厂方法（Static Factory Method）,它不属于23种设计模式之一。

2. 简单工厂模式，是由工厂决定创建出哪一种产品类的实例，是工厂模式家族中最简单的模式.。

   优点：

   1. 简单工厂设计模式解决了客户端直接依赖于具体对象的问题。客户端消除了创建对象的责任，仅仅承担使用的责任。简单工厂模式实现了对责任的分割。

   2. 简单工厂也起到了代码复用的作用。

      

   缺点：

   1. 系统扩展困难，一旦加入新功能，就必须要修改工厂逻辑。
   2. 简单工厂集合了所有创建对象的逻辑，一旦不能正常工作，会导致整个系统出现问题。
   
   ![image-20230427220322004](image/image-20230427220322004.png)

 违反开闭原则所以， 就要使用工厂方法 。

### 工厂方法模式（Factory Method）

定义：一个用于创建对象接口，让子类决定实体化哪一个类，工厂方法使用一个的实例化，延迟到子类。

细节依赖抽象

给每个子类对象 创建一个工厂

![image-20230427233027115](image/image-20230427233027115.png)

![工厂方法](image/image-20230429201055294.png)



`抽象工厂角色:这是工厂方法模式的核心，是具体的工厂角色必须实现的接口或者必须继承的抽象类。`

`具体工厂角色:它包含和具体业务逻辑有关的代码。由应用程序调用以创建对应的具体产品对象。` 

`抽象产品角色:它是具体产品继承的父类或者接口。`

 `具体产品角色类:具体工厂角色创建的对象，就是该类的实例。`

**优点：**

1. 一个调用者想创建一个对象，只要知道其名称就可以了。

2. 扩展性高，如果想增加一个产品，只要扩展一个工厂类就可以。 

3. 屏蔽产品的具体实现，调用者只关心产品的接口。

4. 用户只关系产品类工厂就可以了，无须关心创建细节。

   新加入产品类时，无须修改抽象工厂和抽象产品提供的接口，无须修改客户端，也无须修改其他的具体工厂和具体产品，而只要添加一个具体工厂和具体产品就可以了

**缺点：**

​     每次增加一个产品时，都需要增加一个具体类和对象实现工厂，使得系统中类的个数成倍增加，在一定程度上增加了系统的复杂度，同时也增加了系统具体类的依赖。这并不是什么好事。

工厂方法模式和简单工厂模式的区别

**简单工厂模式（静态工厂）：**

（1）工厂类负责创建的对象比较少，由于创建的对象较少，不会造成工厂方法中的业务逻辑太过复杂。

（2）客户端只知道传入工厂类的参数，对于如何创建对象并不关心。

 （3）当须加入新产品时， 就要修改 产品工厂类，无法做到 开闭原则

**工厂方法模式：**

（1）客户端不知道它所需要的对象的类。

（2）抽象工厂类通过其子类来指定创建哪个对象。

### 抽象工厂模式（Abstract Factory Pattern）

定义：为了缩减创建子类工厂的数量，不必给每一个产品分配一个工厂类，可以将产品进行分组，每组中的不同产品由同一个工厂类的不同方法来创建。

核心：同一产品生产同一类型产品

**优点：**

当一个产品族中的多个对象被设计成一起工作时，它能保证客户端始终只使用同一个产品族中的对象。

**缺点：**

1. 产品族扩展非常困难，要增加一个系列的某一产品，既要在抽象的 Creator 里加代码，又要在具体的里面加代码。
2.  由于采用该模式需要向应用中引入众多接口和类， 代码可能会比之前更加复杂。

![抽象工厂模式](image/image-20230430130113298.png)

​                                        **每个具体工厂类都对应一个特定的产品变体。**

 跟工厂族有点像？

`抽象工厂角色:这是抽象工厂模式的核心，是具体的工厂角色必须实现的接口或者必须继承的抽象类。(分组)`

`具体工厂角色，它包含和具体业务逻辑有关的代码。由应用程序调用以创建对应的具体产品对象。`

`抽象产品角色:它是具体产品继承的父类或者接口。`

`具体产品角色类:具体工厂角色创建的对象，就是该类的实例。`



![image-20230426214659409](image/image-20230426214659409.png)

![image-20230430151553089](image/image-20230430151553089.png)

**抽象工厂模式和工厂方法模式对比**

**抽象工厂模式的定义：**为创建一组相关或相互依赖的对象提供一个接口，而且无需指定它们的具体类。
**工厂方法模式的定义：**为某个对象提供一个接口，而且无需指定它们的具体类。
都是子类实现接口的方法，并在子类写具体的代码。

工厂方法模式中也是可以有多个具体工厂，也是可以有多个抽象产品，和多个具体工厂、具体产品类。

区别是在抽象工厂接口类中，能创建几个产品对象。 

抽象工厂模式的工厂能创建多个相关的产品对象，而工厂方法模式的工厂只创建一个产品对象。

#### 工厂模式总结

简单工厂︰一个工厂类，一个产品抽象类，工厂类创建方法依据传入参数并判断，选择创建具体产品对象。

```c#
public class ProductFactory
{
    
    public static IProduct Create (sting x)
    {
         switch(x)
         {
              case "Product1":   
               return IProduct =new () Product1 ;
                 case "Product1":
               return IProduct  = new () Product2;
         }
    }
}

ProductFactory.Create("xx1"); 
```

工厂方法︰多个工厂类，一个产品抽象类，利用多态创建不同的产品对象，避免了大量的switch-case判断。

解决工厂的switch

```c#
public interface IProduct {
    
    void  Create();
}

public class Product:IProduct
{
    
    public void Create()
    {
       
    }
}

public interface IProductFactory
{
    
    IProduct GetIProduct();
}

public class ProductFactory:IProductFactory
{
    
    public IProduct GetIProduct()
    {
        return new Product();
    }
}


IProductFactory productFactory= new ProductFactory();
IProduct product = productFactory.GetIProduct();
product.Create();
```

抽象工厂︰多个工厂类，多个产品抽象类，产品子类分组，同一个工厂实现类创建同组中的不同产品，减少了工厂子类的数量。

```c#
public interface IAbastractProduct1
{
    void ShowAbastractProduct1();
}

public interface IAbastractProduct2
{
    void ShowAbastractProduct2();
}


public class  AbastractProduct1:IAbastractProduct1
{
    public void ShowAbastractProduct1()
    {
        
        
    }
}


public class  AbastractProduct2:IAbastractProduct2
{
    public void ShowAbastractProduct2()
    {
        
        
    }
}

public interface IAbastractProductFactory
{
    IAbastractProduct1 GetAbastractProduct1();
    IAbastractProduct2 GetAbastractProduct2();
}

public class ProductFactory:IAbastractProductFactory
{
    
   public IAbastractProduct1 GetAbastractProduct1()
   {
       return new AbastractProduct1();
   }
   public IAbastractProduct2 GetAbastractProduct2()
    {
        return new AbastractProduct2();
    }
}

IAbastractProductFactory factory = new ProductFactory();
factory.GetAbastractProduct1().ShowAbastractProduct1();
factory.GetAbastractProduct2().ShowAbastractProduct2();
```

``工厂方法模式与抽象工厂模式都属于创建型模式，在工厂方法模式中弥补了简单工厂模式的缺陷（不符合开闭原则），而在抽象工厂模式中弥补了工厂方法模式的不足（一个工厂只能生产一种产品）。`

### 建造者模式（Builder Pattern）

又称生成器模式

定义：

在软件系统中，有时候面临着"一个复杂对象"的创建工作，其通常由各个部分的子对象用一定的算法构成；由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定。

是将一个复杂对象的构建和它的表示分离，使用同样的构建过程，可以创建不同的表示。

![解析图](image/image-20230427195803547.png)

**注意事项：**与工厂模式的区别是：建造者模式更加关注与零件装配的顺序。

建造者模式结构：

1. AbstractBuilder/Builder((抽象建造者/生成器)
   为创建一个产品对象的各个部件指定抽象接口，在该接口或者抽象类中，一般提供两种方法，第一种就是各个组件的创建方法，
   另一类方法是对象返回方法，用于将构建完成的对象返回。

2. ConcreteBuilder(具体建造者/具体生成器)
   具体建造者实现或者继承抽象建造者,实现各个组件的创建方法和对象方法的方法。

3. Product(产品)
   被构建的复杂对象，包含多个组件。

4. Director(指挥者/主管)
   指挥者负责安排复杂对象的建造顺序。

   这个类的职责就是监工

5.  Client(客户端)

    必须将某个建造者对象与主管类关联。 一般情况下， 你只需通过主管类构造函数的参数进行一次性关联即可。 此后主管类就能使用建造者对象完成后续所有的构造任务。 但在客户端将建造者对象传递给主管类制造方法时还有另一种方式。 在这种情况下， 你在使用主管类生产产品时每次都可以使用不同的建造者。

   ![建造者](image/image-20230427163913491.png)

   

   ![显示图](image/image-20230427195432360.png)

   [设计模式之建造者(Builder)模式 | 菜鸟教程 (runoob.com)](https://www.runoob.com/w3cnote/builder-pattern.html)

   [设计模式：Builder模式 | 菜鸟教程 (runoob.com)](https://www.runoob.com/w3cnote/builder-pattern-2.html)

### 原型模式（Prototype Pattern）

定义：是用于创建重复的对象，同时又能保证性能。