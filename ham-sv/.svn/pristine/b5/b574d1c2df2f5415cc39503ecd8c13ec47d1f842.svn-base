package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　起動時データ取得の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetRepDataForCostMngResult  extends AbstractServiceResult {

    /* =============================================================================================*/
    /** ListだけではWebサービスに公開されないのでダミープロパティを追加 */
    private String _dummy;

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを取得します
     * @return String ダミープロパティ
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * ListだけではWebサービスに公開されないのでダミープロパティを設定します
     * @param dummy ダミープロパティ
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** 制作原価表／制作費表のヘッダ用データリスト */
    private List<RepDataForCostMngHeaderVO> _repDataForCostMngHeader = null;
    /** 制作原価表／制作費表の明細用データリスト */
    private List<RepDataForCostMngDetailsVO> _repDataForCostMngDetails = null;


    /**
     * 制作原価表／制作費表のヘッダ用データリストを取得します
     * @return
     */
    public List<RepDataForCostMngHeaderVO> getRepDataForCostMngHeader() {
        return _repDataForCostMngHeader;
    }

    /**
     * 制作原価表／制作費表のヘッダ用データリストを設定します
     * @param repDataForCostMngHeader
     */
    public void setRepDataForCostMngHeader(List<RepDataForCostMngHeaderVO> repDataForCostMngHeader) {
        _repDataForCostMngHeader = repDataForCostMngHeader;
    }

    /**
     * 制作原価表／制作費表の明細用データリストを取得します
     * @return
     */
    public List<RepDataForCostMngDetailsVO> getRepDataForCostMngDetails() {
        return _repDataForCostMngDetails;
    }

    /**
     * 制作原価表／制作費表の明細用データリストを設定します
     * @param repDataForCostMngDetails
     */
    public void setRepDataForCostMngDetails(List<RepDataForCostMngDetailsVO> repDataForCostMngDetails) {
        _repDataForCostMngDetails = repDataForCostMngDetails;
    }

}
