# 立项原因:
##前段时间,集团公司进行了所谓的停车位管制.我所在的子公司只被分到10来个车位.而且车位所在的位置不好进出。近期上班与回家一个入主干道的路口施工,堵车起来更加恼火.所性抽些时间写了这个玩意儿.
# 项目介绍:
##一个简单的定位系统,收集定位信息.加入微信公众号的授权主要是考虑后期拓展的时候的身份校验作准备,同时微信的受众范围更广.</br>
##当前只开发到了收集信息的阶段.</br>
##1、收集到定位信息后,校验后算出距离一公里内相同目标且出发时间匹配用户.无车用户将从自己匹配到的用车用户中联系到自己车位.双放达成协议后,有车用户修改信息减少一个车位.直至车位减少为0时,此用户将不显示.</br>
##2、收集到定位信息后,集团公司可以将这些经纬度导出到excel中,然后再处理后分目标地址将经纬度导入google earth中,可以很直观的看到员工的位置信息.然后可以更有效果与更低损耗的路线来安排集团接送大巴.</br>
# 可拓展性:
    1、是否可以每个城市都拥有一个自己的此类公众号来收集定位信息,从而减少大家上班的时候开车的次数?有些城市规定副驾驶在工作日必须有人,但是却未提供很有效,同时具有监管性的拼车方式.</br>
    2、通过经纬度与目标地址的分析，是否能达到更有效的安排公交路线？</br>
# 总结：
    个人觉得，减少拥堵与推广绿色出行。并不是一味的提高开车出行的成本，而是车辆与车座的复用。特别是一些总部员工非常多的集团大公司，在同一个城市里就算员工住得再分散也会有很多的同事是住在相同区域内或可以顺路带上的。但是很多公司却只是收集员工描述的住址，就算再本地通的人也无法从这么多信息中分析出哪些可以拼车。</br>
    然而这个项目我自己觉得，应该能解决一部分问题。但是效果需要公司收集到相关的信息进行分析后才能知道效果。
# 相关技术
    前端UI使用的是微信开源的weui来写的,并未进行二次开发.js则使用了轻量级的zepto.js.整体需要加载的东西非常的少.</br>
    后端使用的是asp.net mvc4,ORM则用的是很早版本的petapoco的源码.我自己对强类型的依赖并不是太高..而且我更倾向dbfirst</br>
    此项目是我第一次使用autofac进行开发,当时计划使用autofac就是想试一下去掉了bll层,直接由controler处理大部分逻辑,更进一步的复杂的逻辑则使用DAL进行处理.由于项目较小,看不出太多的坏处.但是好处就是代码更加简单了,同是少掉一层会提升一点点性能吧.没有时间做进一步的测试,未知;希望大家能帮忙分析一下.</br>
# 注册页面
![注册页面](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/7.png)
# 个人中心
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/1.png)
<h1>修改个人信息
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/4.png)
#目标地址管理
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/2.png)
<h1>目标地址编辑<h1>
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/3.png)
<h1>出发地址管理<h1>
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/5.png)
<h1>出发地址编辑<h1>
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/6.png)
<h1>放在google earth上面的效果<h1>
![image](https://raw.githubusercontent.com/lcjyslqyy/-locationproject/master/webimages/6.png)
