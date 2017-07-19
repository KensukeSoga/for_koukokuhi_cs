package jp.co.isid.ham.integ.tbl;

/**
 * <P>
 * massシステム ビュー
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class VbjChargeGrpMedia {

    /**
     * インスタンス生成禁止
     */
    private VbjChargeGrpMedia() {
    }

    /** massシステム ビュー (VBJ_CHARGEGRPMEDIA) */
    public static final String TBNAME = "VBJ_CHARGEGRPMEDIA";

    /** Prefix */
    public static final String PREFIX = "";

    /** 営業所コード (VOP_BJ_EGSYOCD) */
    public static final String VOP_BJ_EGSYOCD = PREFIX + "VOP_BJ_EGSYOCD";

    /** 担当グループ (VOP_BJ_TNTGRP) */
    public static final String VOP_BJ_TNTGRP = PREFIX + "VOP_BJ_TNTGRP";

    /** 媒体コード (VOP_BJ_BTAICD) */
    public static final String VOP_BJ_BTAICD = PREFIX + "VOP_BJ_BTAICD";

    /** 県版コード (VOP_BJ_KBANCD) */
    public static final String VOP_BJ_KBANCD = PREFIX + "VOP_BJ_KBANCD";

}
