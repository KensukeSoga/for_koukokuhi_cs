package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * CR制作費　起動時データ取得の条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetIniDataForCheckListCondition implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 基準日(YYYYMMDD) */
    private String _baseDate = null;

    /**
     * 基準日を取得する
     *
     * @return 基準日
     */
    public String getBaseDate() {
        return _baseDate;
    }

    /**
     * 基準日を設定する
     *
     * @param userid 基準日
     */
    public void setBaseDate(String baseDate) {
        this._baseDate = baseDate;
    }
}
