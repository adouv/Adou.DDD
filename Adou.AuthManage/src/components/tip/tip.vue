<template>
    <transition name="adou-tip-fade">
        <div :class="['adou-tip',type && !icnoClass?`adou-tip--${type}`:'',center?'is-center':'',customClass]"
             v-show="visible"
             @mouseenter="clearTimer"
             @mouseleave="startTimer"
             @click="close"
             role="tip">
            <div class="default show">
                <i :class="iconClass" v-if="iconClass"></i>
                <i :class="typeClass" v-else></i>
                <slot>
                    <p class="adou-tip__content">{{message}}</p>
                </slot>
            </div>
        </div>
    </transition>
</template>

<script>
    const typeMap = {
        success: 'success',
        info: 'info',
        warning: 'warning',
        error: 'error'
    };
    export default {
        name: "TipComponent",
        data() {
            return {
                visible: false,
                message: "这是tip提示！",
                duration: 3500,
                type: 'info',
                iconClass: '',
                customClass: '',
                onClose: null,
                closed: false,
                timer: null,
                center: false
            }
        },
        computed: {
            typeClass() {
                return this.type && !this.iconClass
                    ? `el-message__icon el-icon-${typeMap[this.type]}`
                    : '';
            }
        },
        watch: {
            closed(newVal) {
                if (newVal) {
                    this.visible = false;
                    this.destroyElement();
                }
            }
        },
        methods: {
            destroyElement() {
                this.$destroy(true);
                this.$el.parentNode.removeChild(this.$el);
            },
            close() {
                this.closed = true;
                if (typeof this.onClose === 'function') {
                    this.onClose(this);
                }
            },
            clearTimer() {
                clearTimeout(this.timer);
            },
            startTimer() {
                if (this.duration > 0) {
                    this.timer = setTimeout(() => {
                        if (!this.closed) {
                            this.close();
                        }
                    }, this.duration);
                }
            },
            keydown(e) {
                if (e.keyCode === 27) {
                    if (!this.closed) {
                        this.close();
                    }
                }
            }
        },
        mounted() {
            this.startTimer();
            document.addEventListener('keydown', this.keydown);
        },
        beforeDestroy() {
            document.removeEventListener('keydown', this.keydown);
        }
    }
</script>

<style lang="scss">
    .adou-tip-fade-enter,
    .adou-tip-fade-leave-active {
        opacity: 0;
        transform: translate(-50%, -100%);
    }
</style>