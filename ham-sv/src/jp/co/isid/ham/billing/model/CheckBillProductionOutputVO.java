package jp.co.isid.ham.billing.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 制作費取込VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 J.Kamiyama)<BR>
 * </P>
 * @author J.Kamiyama
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class CheckBillProductionOutputVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public CheckBillProductionOutputVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new CheckBillProductionOutputVO();
    }

    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCarCd() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCarCd(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
    }

}
