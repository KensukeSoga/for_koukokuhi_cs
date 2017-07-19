package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;


@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractSearchResult extends AbstractServiceResult {

    /**
     * �_���񃊃X�g�ϐ�
     */
    private List<ContractSearchVO> _cntrctList = null;

    /**
     * �_���񃊃X�g��ݒ肵�܂�
     * @param val �_���񃊃X�g
     */
    public void setCntrctList(List<ContractSearchVO> val) {
        _cntrctList = val;
    }

    /**
     * �_���񃊃X�g���擾���܂�
     * @return �_���񃊃X�g
     */
    public List<ContractSearchVO> getCntrctList() {
        return _cntrctList;
    }
}
