package jp.co.isid.ham.media.model;

import java.io.Serializable;

/**
 * <P>
 * ラジオ番組登録画面素材情報検索条件
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimtoo)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramMaterialCondition implements Serializable{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 期間開始月 */
    private String _termFrom = null;
    /** 期間終了月 */
    private String _termTo = null;

    /**
     * 期間開始月を取得
     * @return String 期間開始月
     */
    public String getTermFrom() {
        return _termFrom;
    }

    /**
     * 期間開始月を設定
     * @param val String 期間開始月
     */
    public void setTermFrom(String val) {
        _termFrom = val;
    }

    /**
     * 期間終了月を取得
     * @return String 期間終了月
     */
    public String getTermTo() {
        return _termTo;
    }

    /**
     * 期間終了月を設定
     * @param val String 期間終了月
     */
    public void setTermTo(String val) {
        _termTo = val;
    }

}
