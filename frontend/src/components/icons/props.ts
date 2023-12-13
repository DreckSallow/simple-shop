export interface IconProps {
	height?: number | string;
	width?: number | string;
	className?: string;
}

export function strain(props: IconProps): IconProps {
	return {
		height: props.height ?? "18",
		width: props.width ?? "18",
		className: props.className,
	};
}
