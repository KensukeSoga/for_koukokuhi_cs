package jp.co.isid.ham.billing.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Tbj05EstimateItemVO;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC媒体費作成登録VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/5/10 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class RegisterOutputFileInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** 見積案件 */
    private List<Tbj05EstimateItemVO> _estimateItem = null;


    /**
     * デフォルトコンストラクタ
     */
    public RegisterOutputFileInfoVO() {
    }

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    @Override
    public Object newInstance() {
        return new RegisterOutputFileInfoVO();
    }

    /**
     * 見積案件を取得します
     *
     * @return 見積案件
     */
    public List<Tbj05EstimateItemVO> getEstimateItem() {
        return _estimateItem;
    }

    /**
     * 見積案件を設定します
     *
     * @param estimateItem 見積案件
     */
    public void setEstimateItem(List<Tbj05EstimateItemVO> estimateItem) {
        _estimateItem = estimateItem;
    }

}
