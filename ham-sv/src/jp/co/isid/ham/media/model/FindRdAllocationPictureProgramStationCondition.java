package jp.co.isid.ham.media.model;

import java.io.Serializable;

/**
 * <P>
 * ラジオ版AllocationPicture番組ネット局情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/12/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdAllocationPictureProgramStationCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 出力対象 */
    private String _rdSeqNo = null;

    /**
     * 出力対象を取得する
     * @return String 出力対象
     */
    public String getRdSeqNo() {
        return _rdSeqNo;
    }

    /**
     * 出力対象を設定する
     * @param val String 出力対象
     */
    public void setRdSeqNo(String val) {
        _rdSeqNo = val;
    }

}