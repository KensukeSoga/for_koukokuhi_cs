package jp.co.isid.ham.media.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj11CarSec;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * 担当者マスタVO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindCarListVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * デフォルトコンストラクタ
     */
    public FindCarListVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new FindCarListVO();
    }

    /**
     * 系列コードを取得する
     *
     * @return 系列コード
     */
    public String getKEIRETSUCD() {
        return (String) get(Mbj05Car.KEIRETSUCD);
    }

    /**
     * 系列コードを設定する
     *
     * @param val 系列コード
     */
    public void setKEIRETSUCD(String val) {
        set(Mbj05Car.KEIRETSUCD, val);
    }


    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD05() {
        return (String) get(Mbj05Car.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD05(String val) {
        set(Mbj05Car.DCARCD, val);
    }


    /**
     * 車種名を取得する
     *
     * @return 車種名
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * 車種名を設定する
     *
     * @param val 車種名
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }


    /**
     * ソートNoを取得する
     *
     * @return ソートNo
     */
    @XmlElement(required = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj05Car.SORTNO);
    }

    /**
     * ソートNoを設定する
     *
     * @param val ソートNo
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj05Car.SORTNO, val);
    }


    /**
     * 電通車種コードを取得する
     *
     * @return 電通車種コード
     */
    public String getDCARCD11() {
        return (String) get(Mbj11CarSec.DCARCD);
    }

    /**
     * 電通車種コードを設定する
     *
     * @param val 電通車種コード
     */
    public void setDCARCD11(String val) {
        set(Mbj11CarSec.DCARCD, val);
    }


    /**
     * 権限を取得する
     *
     * @return 権限
     */
    public String getAUTHORITY() {
        return (String) get(Mbj11CarSec.AUTHORITY);
    }

    /**
     * 権限を設定する
     *
     * @param val 権限
     */
    public void setAUTHORITY(String val) {
        set(Mbj11CarSec.AUTHORITY, val);
    }

}
