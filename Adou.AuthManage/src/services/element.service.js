export default {
    /**
        *获取屏幕类型
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
        *是否手机
        * @param options {PhoneSize,TabletSize,DesktopSize}
        */
    isPhone: (options) => {
        let windowWidth = document.documentElement.clientWidth;
        if (windowWidth <= options.PhoneSize) {//手机
            return true;
        } else {//桌面、平板
            return false;
        }
    }

}