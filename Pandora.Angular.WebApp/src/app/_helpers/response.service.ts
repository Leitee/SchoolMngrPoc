export class Response<T>
{
	public data: T;
	public errors: string[];
	public hasError: boolean;
	public errorsCount: number;
	public errorCode: number;	

	constructor() {
		this.errors = new Array<string>();
	}
}