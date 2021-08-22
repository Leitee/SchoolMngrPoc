import { ShiftTimeEnum } from '@/_models';

export class Utils {

    static getShiftEnumName(shift: ShiftTimeEnum){
        if(shift == ShiftTimeEnum.TOMORROW)
            return "Mañana";
        else if (shift == ShiftTimeEnum.AFTERNOON)
            return "Tarde";
        else
            return "Noche";
    }
}