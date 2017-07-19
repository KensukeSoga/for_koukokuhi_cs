package jp.co.isid.ham.production.model;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * 支払先一覧の検索実行時のデータ取得条件クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/04/01 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindPayDataCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 基準日付(YYYYMMDD) */
    private String _baseDate = null;

    /** 局コード */
    private String _kykCd = null;

    /** 検索方法種別(1:前方一致 2:部分一致) */
    private int _searchKind = 0;

    /** 名称 */
    private String _name = null;

    /**
     * 営業所コード
     */
    private String _egsCd = null;


    /**
     * 基準日付(YYYYMMDD)を取得する
     *
     * @return 基準日付(YYYYMMDD)
     */
    public String getBaseDate() {
        return _baseDate;
    }

    /**
     * 基準日付(YYYYMMDD)を設定する
     *
     * @param baseDate 基準日付(YYYYMMDD)
     */
    public void setBaseDate(String baseDate) {
        this._baseDate = baseDate;
    }

    /**
     * 検索方法種別を取得する
     *
     * @return 検索方法種別
     */
    public int getSearchKind() {
        return _searchKind;
    }

    /**
     * 検索方法種別を設定する
     *
     * @param kykCd 検索方法種別
     */
    public void setSearchKind(int searchKind) {
        this._searchKind = searchKind;
    }

    /**
     * 局コードを取得する
     *
     * @return 局コード
     */
    public String getKykCd() {
        return _kykCd;
    }

    /**
     * 局コードを設定する
     *
     * @param kykCd 局コード
     */
    public void setKykCd(String kykCd) {
        this._kykCd = kykCd;
    }

    /**
     * 名称を取得する
     *
     * @return 名称
     */
    public String getName() {
        return _name;
    }

    /**
     * 名称を設定する
     *
     * @param name 名称
     */
    public void setName(String name) {
        this._name = name;
    }

    /**
     * 営業所コードを取得する
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * 営業所コードを設定する
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }

}
