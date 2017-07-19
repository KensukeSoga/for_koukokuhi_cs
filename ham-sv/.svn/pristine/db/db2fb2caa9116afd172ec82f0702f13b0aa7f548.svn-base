package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.CarListVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* 車種一覧の情報を保持する.
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2013/03/27 T.Hadate)<BR>
* </P>
* @author T.Hadate
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindCarListResult extends AbstractServiceResult {

    /** 車種一覧の取得 */
    private List<CarListVO> _car;

    /**
     * 車種一覧VOリストを取得します
     * @return _car
     */
    public List<CarListVO> getCarList() {
        return _car;
    }

    /**
     * 車種一覧VOリストを設定します
     * @param _car セットする _car
     */
    public void setCarList(List<CarListVO> car) {
        _car = car;
    }

    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを追加を設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
}
