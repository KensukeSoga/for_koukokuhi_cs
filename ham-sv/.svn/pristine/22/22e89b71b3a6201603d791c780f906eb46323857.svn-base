package jp.co.isid.ham.media.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj02EigyoDaicho;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * スペースVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/02/18 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindSpaceVO extends AbstractModel{

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindSpaceVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindSpaceVO();
    }

    /**
     * スペースを取得
     * @return スペース
     */
    public String getSPACE() {
        return (String) get(Tbj02EigyoDaicho.SPACE);
    }

    /**
     * スペースをセット
     * @param val
     */
    public void setSPACE(String val) {
        set(Tbj02EigyoDaicho.SPACE, val);
    }
}
