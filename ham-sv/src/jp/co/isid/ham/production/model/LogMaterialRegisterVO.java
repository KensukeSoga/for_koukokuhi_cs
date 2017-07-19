package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.common.model.Tbj25LogSozaiKanriDataVO;

/**
 * <P>
 * 素材登録画面ログVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/04 HAMチーム)<BR>
 * </P>
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class LogMaterialRegisterVO extends Tbj25LogSozaiKanriDataVO {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public LogMaterialRegisterVO() {
        //スーパークラスのコンストラクタを呼び出す
        super();
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new LogMaterialRegisterVO();
    }

    /**
     * 車種名称を取得する
     *
     * @return 車種名称
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名称を設定する
     *
     * @param val 車種名称
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }
}
