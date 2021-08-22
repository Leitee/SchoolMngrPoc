export interface DialogData {
    title: string;
    message: string;
    icon: DialogIconEnum;
}

export const enum DialogIconEnum {
    INFO = 'info',
    WARN = 'warning',
    ERROR = 'error'
}