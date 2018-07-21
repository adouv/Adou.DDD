export default {
    /**
   * 获取屏幕类型
   * @param options {PhoneSize,TabletSize,DesktopSize}
   */
    getScreenCategory: (options) => {

        let windowWidth = document.documentElement.clientWidth;
        if (windowWidth <= options.PhoneSize) {//手机
            console.log('phone');
        } else if (windowWidth <= options.TabletSize && windowWidth > options.PhoneSize) {//平板
            console.log('tablet');
        } else {//桌面
            console.log('desktop');
        }
    },
    /**
   * 是否手机
   * @param options {PhoneSize,TabletSize,DesktopSize}
   */
    isPhone: (options) => {
        let windowWidth = document.documentElement.clientWidth;
        if (windowWidth <= options.PhoneSize) {//手机
            return true;
        } else {//桌面、平板
            return false;
        }
    },
    /**
   * 判断body是否包含某个样式
   * @param {*} ref 标签
   * @param {*} className 样式名称
   */
    refHasClass(ref, className) {
        return ref.className.indexOf(className) > -1;
    },
    /**
     * 给body添加样式
     * @param {*} ref 标签
     * @param {*} className 样式名称 
     */
    refAddClass(ref, className) {
        let classList = ref.className.split(" ");
        if (classList !== null) {
            classList.push(className);
        }
        ref.className = classList.join(" ");
    },
    /**
     * 移除body的某个样式
     * @param {*} ref 标签
     * @param {*} className 样式名称 
     */
    refRemoveClass(ref, className) {
        let classList = ref.className.split(" ");
        if (classList !== null) {
            ref.className = classList
                .filter((value, index, array) => {
                    return value !== className;
                })
                .join(" ");
        }
    }

}